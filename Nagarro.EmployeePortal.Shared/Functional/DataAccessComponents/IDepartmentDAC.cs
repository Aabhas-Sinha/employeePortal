using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public interface IDepartmentDAC : IDataAccessComponent
    {
        IDepartmentDTO GetADepartment(int departmentId);
        IList<IDepartmentDTO> GetAllDepartments();

    }
}
