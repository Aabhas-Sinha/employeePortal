namespace Nagarro.EmployeePortal.Shared
{
    /// <summary>
    /// Data Access Component Type
    /// </summary>
    public enum DACType
    {
        /// <summary>
        /// Undefined DAC (Default)
        /// </summary>
        Undefined = 0,
        [QualifiedTypeName("Nagarro.EmployeePortal.Data.dll", "Nagarro.EmployeePortal.Data.NoticeManagerDAC")]
        NoticeManagerDAC = 1,

        [QualifiedTypeName("Nagarro.EmployeePortal.Data.dll", "Nagarro.EmployeePortal.Data.IssueManagerDAC")]
        IssueManagerDAC = 2,

        [QualifiedTypeName("Nagarro.EmployeePortal.Data.dll", "Nagarro.EmployeePortal.Data.EmployeeManagerDAC")]
        EmployeeManagerDAC = 3,

        [QualifiedTypeName("Nagarro.EmployeePortal.Data.dll", "Nagarro.EmployeePortal.Data.UserManagerDAC")]
        UserManagerDAC = 4,

        [QualifiedTypeName("Nagarro.EmployeePortal.Data.dll", "Nagarro.EmployeePortal.Data.DepartmentManagerDAC")]
        DepartmentManagerDAC = 5

    }
}
