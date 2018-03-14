namespace Nagarro.CasinoApplication.Web.Shared
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    using Nagarro.EmployeePortal.Shared;

    using MappingType = Nagarro.EmployeePortal.Shared.MappingType;

    /// <summary>
    /// Represents viewModel converter,
    /// Author		: Nagarro
    /// </summary>
    public sealed class DTOConverter
    {
        #region Ctor

        /// <summary>
        /// Prevents a default instance of the <see cref="DTOConverter"/> class from being created. 
        /// </summary>
        private DTOConverter()
        {
        }

        #endregion

        #region Conversion Methods

        /// <summary>
        /// Fills the DTO from viewModel.
        /// </summary>
        /// <param name="toDTO">To dto.</param>
        /// <param name="fromViewModel">from view model.</param>
        public static void FillDTOFromViewModel(IDTO toDTO, object fromViewModel)
        {
            FillData(fromViewModel, toDTO, false);
        }

        /// <summary>
        /// Fills the viewModel from DTO.
        /// </summary>
        /// <param name="toViewModel">
        /// The View Model to copy to.
        /// </param>
        /// <param name="fromDTO">
        /// The DTO to copy from.
        /// </param>
        public static void FillViewModelFromDTO(object toViewModel, IDTO fromDTO)
        {
            FillData(toViewModel, fromDTO, true);
        }

        #region Private Helper Methods

        /// <summary>
        /// Fills the data.
        /// </summary>
        /// <param name="viewModel">The dto.</param>
        /// <param name="dto">The viewModel.</param>
        /// <param name="viewModelFromDto">if private set to <c>true</c> [viewModel from dto].</param>
        private static void FillData(object viewModel, IDTO dto, bool viewModelFromDto)
        {
            var dtoType = dto.GetType();
            var viewModelType = viewModel.GetType();
            MappingType mappingType;

            if (!VerifyForViewModelType(viewModelType, dtoType, out mappingType))
            {
                throw new DTOConversionException(string.Format(Thread.CurrentThread.CurrentCulture, "ViewModel type '{0}' must match with type specified in ViewModelMappingAttribute on type '{1}' !", viewModelType.ToString(), dtoType.ToString()));
            }

            var properties = dtoType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                bool skipThisProperty = false;
                object[] customAttributes = property.GetCustomAttributes(typeof(ViewModelPropertyMappingAttribute), false);
                if (mappingType == MappingType.TotalExplicit && customAttributes.Length == 0)
                {
                    continue;
                }

                foreach (object customAttribute in customAttributes)
                {
                    ViewModelPropertyMappingAttribute entityPropertyMappingAttribute = (ViewModelPropertyMappingAttribute)customAttribute;
                    if (entityPropertyMappingAttribute.MappingDirection == MappingDirectionType.None)
                    {
                        skipThisProperty = true;
                        break;
                    }
                }

                if (skipThisProperty)
                {
                    continue;
                }

                var entityPropertyName = GetEntityPropertyName(property, mappingType, viewModelFromDto);
                if (!string.IsNullOrEmpty(entityPropertyName))
                {
                    var entityProperty = viewModelType.GetProperty(entityPropertyName);

                    if (entityProperty == null)
                    {
                        throw new DTOConversionException(entityPropertyName, dto);
                    }

                    var sourceProperty = viewModelFromDto ? property : entityProperty;
                    var destinationProperty = viewModelFromDto ? entityProperty : property;
                    var sourceObject = viewModelFromDto ? (object)dto : (object)viewModel;
                    var destinationObject = viewModelFromDto ? (viewModel as object) : (dto as object);
                    var sourceValue = sourceProperty.GetValue(sourceObject, null);

                    if (destinationProperty.CanWrite)
                    {
                        if (sourceProperty.PropertyType.IsEnum && destinationProperty.PropertyType == typeof(byte))
                        {
                            sourceValue = (byte)(int)sourceValue;
                        }

                        destinationProperty.SetValue(destinationObject, sourceValue, null);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the name of the viewModel property.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="mappingType">Type of the mapping.</param>
        /// <param name="entityFromDTO">if set to <c>true</c> [viewModel from DTO].</param>
        /// <returns></returns>
        private static string GetEntityPropertyName(PropertyInfo property, MappingType mappingType, bool entityFromDTO)
        {
            string entityPropertyName = string.Empty;
            var attribute =
                        (ViewModelPropertyMappingAttribute)
                        Attribute.GetCustomAttribute(property, typeof(ViewModelPropertyMappingAttribute));

            bool skipMapping = false;

            if (attribute != null)
            {
                if (entityFromDTO)
                {
                    skipMapping = !(attribute.MappingDirection == MappingDirectionType.EntityFromDTO || attribute.MappingDirection == MappingDirectionType.Both);
                }
                else
                {
                    skipMapping = !(attribute.MappingDirection == MappingDirectionType.DTOFromEntity || attribute.MappingDirection == MappingDirectionType.Both);
                }
            }

            switch (mappingType)
            {
                case MappingType.TotalExplicit:
                    if (attribute == null)
                    {
                        throw new DTOConversionException(
                            string.Format(
                                        Thread.CurrentThread.CurrentCulture,
                                        "Property '{0}' should have ViewModelPropertyMappingAttribute !"),
                                        entityPropertyName);
                    }

                    entityPropertyName = skipMapping ? string.Empty : attribute.MappedViewModelPropertyName;
                    break;
                case MappingType.TotalImplicit:
                    if (attribute != null && skipMapping)
                    {
                        entityPropertyName = string.Empty;
                    }
                    else
                    {
                        entityPropertyName = property.Name;
                    }

                    break;
                case MappingType.Hybrid:
                    if (attribute == null)
                    {
                        entityPropertyName = property.Name;
                    }
                    else if (skipMapping)
                    {
                        entityPropertyName = string.Empty;
                    }
                    else
                        entityPropertyName = attribute.MappedViewModelPropertyName;
                    break;
                default:
                    break;
            }

            return entityPropertyName;
        }

        /// <summary>
        /// Verifies the type of for viewModel.
        /// </summary>
        /// <param name="entityType">Type of the viewModel.</param>
        /// <param name="DTOType">Type of the DTO.</param>
        /// <param name="mappingType">Type of the mapping.</param>
        /// <returns></returns>
        private static bool VerifyForViewModelType(Type entityType, Type DTOType, out MappingType mappingType)
        {
            var attributes = DTOType.GetCustomAttributes(typeof(ViewModelMappingAttribute), false);
            if (attributes.Count() == 1)
            {
                var mappingAttribute = (ViewModelMappingAttribute)attributes[0];
                mappingType = mappingAttribute.MappingType;
                return mappingAttribute.MappedViewModelTypeFullName.Equals(entityType.FullName);
            }

            throw new DTOConversionException("Only one ViewModelMappingAttribute can be applied on type '{0}' !", DTOType.ToString());
        }

        #endregion

        #endregion

        #region Singleton Access

        //Todo: Remove singleton access and make the class static

        // Note: ThreadStatic is added over Field here to ensure that each thread 
        // has its unique instance of this class.
        // Since multiple simultaneous calls to this class may come, it is safe
        // to have a seperate copy of this functionality class

        private static volatile DTOConverter instance;
        private static string instanceLock = "LOCK";

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static DTOConverter Instance
        {
            get
            {
                // create object if not available
                if (instance == null)
                {
                    lock (instanceLock)
                    {
                        if (instance == null)
                        {
                            instance = new DTOConverter();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion
    }
}
