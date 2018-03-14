using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.DTOModel
{
    [EntityMapping("Issue", MappingType.TotalExplicit)]
    [ViewModelMapping("Nagarro.EmployeePortal.Web.Issue", MappingType.TotalExplicit)]
    public class IssueDTO : DTOBase, IIssueDTO
    {

        [EntityPropertyMapping(MappingDirectionType.Both, "Description")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Description")]
        public string Description { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "IsActive")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "IsActive")]
        public bool IsActive { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "IssueId")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "IssueId")]
        public int IssueId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "PostedBy")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "PostedBy")]
        public int PostedBy { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Priority")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Priority")]
        public int Priority { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Title")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Title")]
        public string Title { get; set; }

        public IList<IComplexIssueHistoryDTO> IssueHistories { get; set; }

        public IEmployeeDTO EmployeeDTO { get; set; }
    }
}
