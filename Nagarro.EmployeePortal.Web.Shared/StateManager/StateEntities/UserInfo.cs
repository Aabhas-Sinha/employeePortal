using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Web.Shared
{ 
    public class UserInfo: StateEntityBase
    {

        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public EmployeeInfo Employee { get; set; }
        public string Role { get; set; }
    }
}
