namespace Nagarro.EmployeePortal.Web.Shared
{
    /// <summary>
    /// Defines a contract for state manager,
    /// Author		: Nagarro
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStateManager<T> where T : StateEntityBase, new()
    {
        /// <summary>
        /// Gets or sets the state entity.
        /// </summary>
        /// <value>The state entity.</value>
        T StateEntity { get; set; }

        /// <summary>
        /// Gets the key for state entity.
        /// </summary>
        /// <value>The key.</value>
        string Key { get; }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        void Clear();

        /// <summary>
        /// Initializes the state entity.
        /// </summary>
        /// <param name="isFirstTime">if set to <c>true</c> then generates the key else not.</param>
        void Initialize(bool isFirstTime);

        /// <summary>
        /// Generates the key.
        /// </summary>
        /// <returns></returns>
        string GenerateKey();

        /// <summary>
        /// Generates the key.
        /// </summary>
        /// <param name="stateEntity">The state entity.</param>
        /// <returns></returns>
        string GenerateKey(T stateEntity);
    }
}
