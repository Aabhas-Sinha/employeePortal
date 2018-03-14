using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Web.Shared
{
    public class EmployeeInfo: StateEntityBase
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfJoining { get; set; }
        public DateTime? TerminationDate { get; set; }
        public int DepartmentId { get; set; }
    }
}