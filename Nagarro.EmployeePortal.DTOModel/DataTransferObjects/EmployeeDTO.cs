using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.DTOModel
{
    [EntityMapping("Employee", MappingType.TotalExplicit)]
    [ViewModelMapping("Nagarro.EmployeePortal.Web.Shared.EmployeeInfo", MappingType.TotalExplicit)]
    public class EmployeeDTO : DTOBase, IEmployeeDTO
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "DateOfJoining")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "DateOfJoining")]
        public DateTime DateOfJoining { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "DepartmentId")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "DepartmentId")]
        public int DepartmentId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Email")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Email")]
        public string Email { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "EmployeeId")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "EmployeeId")]
        public int EmployeeId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "FirstName")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "FirstName")]
        public string FirstName { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "LastName")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "LastName")]
        public string LastName { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "TerminationDate")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "TerminationDate")]
        public DateTime? TerminationDate { get; set; }

    }
}
