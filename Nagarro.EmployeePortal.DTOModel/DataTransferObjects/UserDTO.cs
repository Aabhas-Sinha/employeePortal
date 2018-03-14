using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.DTOModel
{
    [EntityMapping("User", MappingType.TotalExplicit)]
    [ViewModelMapping("Nagarro.EmployeePortal.Web.Shared.UserInfo", MappingType.TotalExplicit)]
    public class UserDTO : DTOBase, IUserDTO
    {
        [ViewModelPropertyMapping(MappingDirectionType.Both, "EmployeeId")]
        [EntityPropertyMapping(MappingDirectionType.Both, "EmployeeId")]
        public int EmployeeId { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "IsAdmin")]
        [EntityPropertyMapping(MappingDirectionType.Both, "IsAdmin")]
        public bool IsAdmin { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "Password")]
        [EntityPropertyMapping(MappingDirectionType.Both, "Password")]
        public string Password { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "UserId")]
        [EntityPropertyMapping(MappingDirectionType.Both, "UserId")]
        public int UserId { get; set; }

        public IEmployeeDTO EmployeeDTO { get; set; }
    }
}
