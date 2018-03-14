using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public interface IUserDAC : IDataAccessComponent
    {
        IUserDTO UpdateProfile(IUserDTO userDTO);
        IUserDTO Login(string username, string password);
        IUserDTO GetUserByEmailId(string emailId);
        IUserDTO CreateEmployeeByTransaction(IUserDTO userDTO);
        IUserDTO CreateEmployeeBySProc(IUserDTO userDTO);
        IUserDTO UpdateEmployee(IUserDTO userDTO);
        IList<IUserDTO> GetAdmins();
        IList<IEmployeeDTO> SearchEmployeeByRawQuery(ISearchEmployeeDTO searchEmployeeDTO, bool checkTerminationDate);
    }
}
