using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public interface IUserDTO : IDTO
    {
        int UserId { get; set; }
        int EmployeeId { get; set; }
        string Password { get; set; }
        bool IsAdmin { get; set; }
        IEmployeeDTO EmployeeDTO { get; set; }
    }
}
