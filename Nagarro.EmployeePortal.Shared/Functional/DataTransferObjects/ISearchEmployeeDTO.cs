using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public interface ISearchEmployeeDTO : IDTO
    {
        string Firstname { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        DateTime? BeginDate { get; set; }
        DateTime? Enddate { get; set; }
        int? DepartmentId { get; set; }
    }
}
