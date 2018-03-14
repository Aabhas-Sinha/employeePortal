namespace Nagarro.EmployeePortal.Web.Shared
{
    using System;

    /// <summary>
    /// Contains/Represents/Provides View property mapping attribute,
    /// Author		: Nagarro
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ViewPropertyMappingAttribute : Attribute
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewPropertyMappingAttribute"/> class.
        /// </summary>
        /// <param name="mappingDirection">The mapping direction.</param>
        /// <param name="mappedViewPropertyName">Name of the mapped view property.</param>
        public ViewPropertyMappingAttribute(MappingDirectionType mappingDirection, string mappedViewPropertyName)
            : this(mappingDirection)
        {
            // private set value
            MappedViewPropertyName = mappedViewPropertyName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewPropertyMappingAttribute"/> class.
        /// </summary>
        /// <param name="mappingDirection">The mapping direction.</param>
        internal ViewPropertyMappingAttribute(MappingDirectionType mappingDirection)
        {
            // private set value
            MappingDirection = mappingDirection;
        }

        #endregion

        #region ViewPropertyMappingAttribute Members

        /// <summary>
        /// Gets the name of the mapped view property.
        /// </summary>
        /// <value>The name of the mapped view property.</value>
        public string MappedViewPropertyName { get; private set; }

        /// <summary>
        /// Gets the mapping direction.
        /// </summary>
        /// <value>The mapping direction.</value>
        public MappingDirectionType MappingDirection { get; private set; }

        #endregion
    }
}
