using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public interface IUserBDC : IBusinessDomainComponent
    {
        OperationResult<IUserDTO> CreateEmployeeByTransaction(IUserDTO userDTO);
        OperationResult<IUserDTO> CreateEmployeeBySProc(IUserDTO userDTO);
        OperationResult<IUserDTO> GetUserByEmailId(string emailId);
        OperationResult<IUserDTO> Login(string username, string password);
        OperationResult<IList<IEmployeeDTO>> SearchEmployeeByRawQuery(ISearchEmployeeDTO employeeDTO, bool checkTerminationDate);
        OperationResult<IUserDTO> UpdateEmployee(IUserDTO userDTO);
        OperationResult<IUserDTO> UpdateProfile(IUserDTO userDTO);
        OperationResult<IList<IUserDTO>> GetAdmins();
    }
}
