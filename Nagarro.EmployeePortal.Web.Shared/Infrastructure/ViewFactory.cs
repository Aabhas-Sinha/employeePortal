using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nagarro.EmployeePortal.Web.Shared
{
   public class ViewFactory : FactoryBase , IViewFactory
    {
       //mInstance variable completes before the instance variable can be accessed.
        [ThreadStatic]
        private static volatile ViewFactory _Instance;
        private static object _SyncObject = new object();

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="DACFactory"/> class.
        /// </summary>
        private ViewFactory()
        {
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Instance is private static property to return the same Instance of the class everytime.
        /// Note: Double - checked serialized initialization of Class pattern is used.
        /// </summary>
        public static ViewFactory Instance
        {
            get
            {
                #region Single Instance Logic
                //Check for null before acquiring the lock.
                if (_Instance == null)
                {
                    //Use a mSyncObject to lock on, to avoid deadlocks among multiple threads.
                    lock (_SyncObject)
                    {
                        //Again check if mInstance has been initialized, 
                        //since some other thread may have acquired the lock first and constructed the object.
                        if (_Instance == null)
                        {
                            _Instance = new ViewFactory();
                        }
                    }
                }
                #endregion

                return _Instance;
            }
        }
        #endregion

        #region IViewFactory Members

        /// <summary>
        /// Creates the specified DAC type.
        /// </summary>
        /// <param name="type">The DAC type.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public IViewModel Create(ViewType type, params object[] args)
        {
            // get attribuye value
            QualifiedTypeNameAttribute QualifiedNameAttr = EnumAttributeUtility<ViewType, QualifiedTypeNameAttribute>.GetEnumAttribute(type.ToString());
            IViewModel instance = null;
            // create instance

            instance =(IViewModel)this.CreateObjectInstance(QualifiedNameAttr.AssemblyFileName, QualifiedNameAttr.QualifiedTypeName, args);
            return instance;
        }

        #endregion
    }
}
