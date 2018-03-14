using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.DTOModel
{
    [ViewModelMapping("Nagarro.EmployeePortal.Web.SearchEmployee", MappingType.TotalExplicit)]
    public  class SearchEmployeeDTO: DTOBase, ISearchEmployeeDTO
    {
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Firstname")]
        public string Firstname { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "LastName")]
        public string LastName { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "Email")]
        public string Email { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "BeginDate")]
        public DateTime? BeginDate { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "Enddate")]
        public DateTime? Enddate { get; set; }

        [ViewModelPropertyMapping(MappingDirectionType.Both, "DepartmentId")]
        public int? DepartmentId { get; set; }
    }
}
