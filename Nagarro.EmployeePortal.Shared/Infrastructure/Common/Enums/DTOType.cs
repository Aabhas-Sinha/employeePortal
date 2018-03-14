namespace Nagarro.EmployeePortal.Shared
{
    /// <summary>
    /// Data Transfer Objects
    /// </summary>
    public enum DTOType
    {
        /// <summary>
        /// Undefined DTO (Default)
        /// </summary>
        Undefined = 0,
        [QualifiedTypeName("Nagarro.EmployeePortal.DTOModel.dll", "Nagarro.EmployeePortal.DTOModel.NoticeDTO")]
        NoticeDTO = 1,

        [QualifiedTypeName("Nagarro.EmployeePortal.DTOModel.dll", "Nagarro.EmployeePortal.DTOModel.IssueDTO")]
        IssueDTO = 2,

        [QualifiedTypeName("Nagarro.EmployeePortal.DTOModel.dll", "Nagarro.EmployeePortal.DTOModel.EmployeeDTO")]
        EmployeeDTO = 3,

        [QualifiedTypeName("Nagarro.EmployeePortal.DTOModel.dll", "Nagarro.EmployeePortal.DTOModel.UserDTO")]
        UserDTO = 4,

        [QualifiedTypeName("Nagarro.EmployeePortal.DTOModel.dll", "Nagarro.EmployeePortal.DTOModel.IssueHistoryDTO")]
        IssueHistoryDTO = 5,

        [QualifiedTypeName("Nagarro.EmployeePortal.DTOModel.dll", "Nagarro.EmployeePortal.DTOModel.DepartmentDTO")]
        DepartmentDTO = 6,

        [QualifiedTypeName("Nagarro.EmployeePortal.DTOModel.dll", "Nagarro.EmployeePortal.DTOModel.SearchEmployeeDTO")]
        SearchEmployeeDTO = 7,

        [QualifiedTypeName("Nagarro.EmployeePortal.DTOModel.dll", "Nagarro.EmployeePortal.DTOModel.ComplexIssueDTO")]
        ComplexIssueDTO = 8,

        [QualifiedTypeName("Nagarro.EmployeePortal.DTOModel.dll", "Nagarro.EmployeePortal.DTOModel.ComplexIssueHistoryDTO")]
        ComplexIssueHistoryDTO = 9,

    }
}
