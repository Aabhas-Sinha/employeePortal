using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.DTOModel
{
    [EntityMapping("Department", MappingType.TotalExplicit)]
    [ViewModelMapping("Nagarro.EmployeePortal.Web.Department", MappingType.TotalExplicit)]
    public class DepartmentDTO : DTOBase, IDepartmentDTO
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "DepartmentId")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "DepartmentId")]
        public int DepartmentId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "DepartmentName")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "DepartmentName")]
        public string DepartmentName { get; set; }
    }
}
