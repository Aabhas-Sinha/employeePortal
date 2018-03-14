using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.BusinessFacades
{
   public class DepartmentManagerFacade : FacadeBase, IDepartmentFacade
    {
        public DepartmentManagerFacade()
            :base(FacadeType.DepartmentManagerFacade)
        {

        }

        public OperationResult<IDepartmentDTO> GetADepartment(int departmentId)
        {
            IDepartmentBDC departmentBDC = (IDepartmentBDC)BDCFactory.Instance.Create(BDCType.DepartmentManagerBDC);
            return departmentBDC.GetADepartment(departmentId);
        }

        public OperationResult<IList<IDepartmentDTO>> GetAllDepartments()
        {
            IDepartmentBDC departmentBDC = (IDepartmentBDC)BDCFactory.Instance.Create(BDCType.DepartmentManagerBDC);
            return departmentBDC.GetAllDepartments();
        }
    }
}
