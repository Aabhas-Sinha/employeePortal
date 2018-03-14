using System;


namespace Nagarro.EmployeePortal.Web.Shared
{
    /// <summary>
    /// Represents abstract base class for State managers,
    /// Author		: Nagarro
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class StateManagerBase<T> : IStateManager<T> where T : StateEntityBase, new()
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="StateManagerBase&lt;T&gt;"/> class.
        /// </summary>
        internal StateManagerBase()
        {
            //mStateEntity = new T();
            //mKey = mStateEntity.GetType().Name + "_" + mStateEntity.GetType().GUID.ToString();
            //this.StateEntity = mStateEntity;
            this.Initialize(true);
        }
        #endregion

        #region IStateManager<T> Members

        /// <summary>
        /// Gets or sets the state entity.
        /// </summary>
        /// <value>The state entity.</value>
        public virtual T StateEntity
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets or sets the key for state entity.
        /// </summary>
        /// <value>The key.</value>
        public string Key { get; private set; }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public virtual void Clear()
        {
            //this._stateEntity = null;
        }

        /// <summary>
        /// Initializes the State Entity.
        /// </summary>
        /// <param name="isFirstTime">if set to <c>true</c> then generates the key else not.</param>
        public void Initialize(bool isFirstTime)
        {
            T _stateEntity = new T();
            if (isFirstTime)
            {
                Key = this.GenerateKey(_stateEntity); //mStateEntity.GetType().Name + "_" + mStateEntity.GetType().GUID.ToString();
            }
            this.StateEntity = _stateEntity;
        }

        /// <summary>
        /// Generates the key.
        /// </summary>
        /// <returns></returns>
        public string GenerateKey()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates the key on the basis of entity.
        /// </summary>
        /// <param name="stateEntity">The state entity.</param>
        /// <returns></returns>
        public string GenerateKey(T stateEntity)
        {
            return stateEntity.Key;
        }
        #endregion


    }
}
