using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public interface IEmployeeDTO : IDTO
    {
        int EmployeeId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        DateTime DateOfJoining { get; set; }
        DateTime? TerminationDate { get; set; }
        int DepartmentId { get; set; }
    }
}
