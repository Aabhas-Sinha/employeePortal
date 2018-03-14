using System;
using System.Web;


namespace Nagarro.EmployeePortal.Web.Shared
{
    /// <summary>
    /// Represents Session state manager,
    /// Author		: Nagarro
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class SessionStateManager<T> : StateManagerBase<T> where T : StateEntityBase, new()
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionStateManager&lt;T&gt;"/> class.
        /// </summary>
        private SessionStateManager()
        {

        }
        #endregion

        #region Single Instance

        //The variable is declared to be volatile to ensure that assignment to the 
        //mInstance variable completes before the instance variable can be accessed.
        //[ThreadStatic]
        private static volatile SessionStateManager<T> _instance;
        private static object _syncObject = new object();

        /// <summary>
        /// Instance is private static property to return the same Instance of the class everytime.
        /// Note: Double - checked serialized initialization of Class pattern is used.
        /// </summary>
        private static SessionStateManager<T> Instance
        {
            get
            {
                #region Single Instance Logic
                //Check for null before acquiring the lock.
                if (_instance == null)
                {
                    //Use a mSyncObject to lock on, to avoid deadlocks among multiple threads.
                    lock (_syncObject)
                    {
                        //Again check if mInstance has been initialized, 
                        //since some other thread may have acquired the lock first and constructed the object.
                        if (_instance == null)
                        {
                            _instance = new SessionStateManager<T>();
                        }
                    }
                }
                #endregion

                return _instance;
            }
        }
        #endregion

        #region StateEntity

        /// <summary>
        /// Gets or sets the state entity.
        /// </summary>
        /// <value>The state entity.</value>
        public override T StateEntity
        {
            get
            {
                if (HttpContext.Current.Session != null)
                {
                    if (HttpContext.Current.Session[Key] == null)
                    {
                        //this._stateEntity = new T();
                        this.Initialize(false);
                    }
                    return (T)HttpContext.Current.Session[Key];
                }
                else
                {
                    throw new Exception("Session not available !");
                }
            }
            set
            {
                if (HttpContext.Current.Session != null)
                {
                    HttpContext.Current.Session[Key] = value;
                }
            }
        }
        #endregion

        #region Clear
        /// <summary>
        /// Clears this instance.
        /// </summary>
        public override void Clear()
        {
            base.Clear();
            //_instance = null;
            HttpContext.Current.Session.Remove(Key);
        }
        #endregion

        /// <summary>
        /// Gets the data of session entity.
        /// </summary>
        /// <value>The data.</value>
        public static T Data
        {
            get { return Instance.StateEntity; }
        }

        /// <summary>
        /// Clears the data of session entity.
        /// </summary>
        public static void ClearData()
        {
            Instance.Clear();
        }
    }
}
