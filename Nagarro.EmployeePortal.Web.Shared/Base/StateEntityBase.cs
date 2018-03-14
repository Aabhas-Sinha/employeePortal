using System;

namespace Nagarro.EmployeePortal.Web.Shared
{
    /// <summary>
    /// Represents abstract base class for State entities,
    /// Author		: Nagarro
    /// </summary>
    public abstract class StateEntityBase
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="StateEntityBase"/> class.
        /// </summary>
        protected StateEntityBase()
        {
            this.LastUpdatedDateTime = System.DateTime.Now;
        }
        #endregion

        /// <summary>
        /// Gets or private sets the last updated date time.
        /// </summary>
        /// <value>The last updated date time.</value>
        public DateTime LastUpdatedDateTime { get; private set; }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        public string Key
        {
            get
            {
                return this.GetType().Name + "_" + this.GetType().GUID.ToString();
            }

        }
    }
}
