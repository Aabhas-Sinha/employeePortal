using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.BusinessFacades
{
    public class UserManagerFacade : FacadeBase, IUserFacade
    {
        public UserManagerFacade() : base(FacadeType.UserManagerFacade)
        {

        }

        public OperationResult<IUserDTO> CreateEmployeeBySProc(IUserDTO userDTO)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserManagerBDC);
            return userBDC.CreateEmployeeBySProc(userDTO);
        }

        public OperationResult<IUserDTO> CreateEmployeeByTransaction(IUserDTO userDTO)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserManagerBDC);
            return userBDC.CreateEmployeeByTransaction(userDTO);
        }

        public OperationResult<IList<IUserDTO>> GetAdmins()
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserManagerBDC);
            return userBDC.GetAdmins();
        }

        public OperationResult<IUserDTO> GetUserByEmailId(string emailId)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserManagerBDC);
            return userBDC.GetUserByEmailId(emailId);
        }

        public OperationResult<IUserDTO> Login(string username, string password)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserManagerBDC);
            return userBDC.Login(username,password);
        }

        public OperationResult<IList<IEmployeeDTO>> SearchEmployeeByRawQuery(ISearchEmployeeDTO employeeDTO, bool checkTerminationDate)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserManagerBDC);
            return userBDC.SearchEmployeeByRawQuery(employeeDTO,checkTerminationDate);
        }

        public OperationResult<IUserDTO> UpdateEmployee(IUserDTO userDTO)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserManagerBDC);
            return userBDC.UpdateEmployee(userDTO);
        }

        public OperationResult<IUserDTO> UpdateProfile(IUserDTO userDTO)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserManagerBDC);
            return userBDC.UpdateProfile(userDTO);
        }
    }
}
