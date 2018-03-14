using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    /// <summary>
    /// The Facade Types
    /// </summary>
    public enum FacadeType
    {
        /// <summary>
        /// Undefined Facade Type (Default)
        /// </summary>
        Undefined = 0,
        [QualifiedTypeName("Nagarro.EmployeePortal.BusinessFacades.dll", "Nagarro.EmployeePortal.BusinessFacades.NoticeManagerFacade")]
        NoticeManagerFacade = 1,

        [QualifiedTypeName("Nagarro.EmployeePortal.BusinessFacades.dll", "Nagarro.EmployeePortal.BusinessFacades.IssueManagerFacade")]
        IssueManagerFacade = 2,

        [QualifiedTypeName("Nagarro.EmployeePortal.BusinessFacades.dll", "Nagarro.EmployeePortal.BusinessFacades.EmployeeManagerFacade")]
        EmployeeManagerFacade = 3,

        [QualifiedTypeName("Nagarro.EmployeePortal.BusinessFacades.dll", "Nagarro.EmployeePortal.BusinessFacades.UserManagerFacade")]
        UserManagerFacade = 4,

        [QualifiedTypeName("Nagarro.EmployeePortal.BusinessFacades.dll", "Nagarro.EmployeePortal.BusinessFacades.DepartmentManagerFacade")]
        DepartmentManagerFacade = 5

    }
}
