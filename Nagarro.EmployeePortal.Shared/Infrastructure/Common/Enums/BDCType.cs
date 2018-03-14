namespace Nagarro.EmployeePortal.Shared
{
    /// <summary>
    /// Business Domain Component Type
    /// </summary>
    public enum BDCType
    {
        /// <summary>
        /// Undefined BDC (Default)
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Notice Manager
        /// </summary>
        [QualifiedTypeName("Nagarro.EmployeePortal.Business.dll", "Nagarro.EmployeePortal.Business.NoticeManagerBDC")]
        NoticeManagerBDC = 1,

        [QualifiedTypeName("Nagarro.EmployeePortal.Business.dll", "Nagarro.EmployeePortal.Business.IssueManagerBDC")]
        IssueManagerBDC = 2,

        [QualifiedTypeName("Nagarro.EmployeePortal.Business.dll", "Nagarro.EmployeePortal.Business.EmployeeManagerBDC")]
        EmployeeManagerBDC = 3,

        [QualifiedTypeName("Nagarro.EmployeePortal.Business.dll", "Nagarro.EmployeePortal.Business.UserManagerBDC")]
        UserManagerBDC = 4,

        [QualifiedTypeName("Nagarro.EmployeePortal.Business.dll", "Nagarro.EmployeePortal.Business.DepartmentManagerBDC")]
        DepartmentManagerBDC = 5

    }
}
