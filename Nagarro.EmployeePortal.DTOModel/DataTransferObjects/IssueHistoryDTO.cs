using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.DTOModel
{
    [EntityMapping("IssueHistory", MappingType.TotalExplicit)]
    [ViewModelMapping("Nagarro.EmployeePortal.Web.IssueHistory", MappingType.TotalExplicit)]
    public class IssueHistoryDTO : DTOBase, IIssueHistoryDTO
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "AssignedTo")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "AssignedTo")]
        public int? AssignedTo { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Comments")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Comments")]
        public string Comments { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "IssueHistoryId")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "IssueHistoryId")]
        public int IssueHistoryId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "IssueId")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "IssueId")]
        public int IssueId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "ModifiedBy")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "ModifiedBy")]
        public int ModifiedBy { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "ModifiedOn")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "ModifiedOn")]
        public DateTime ModifiedOn { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Status")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Status")]
        public int Status { get; set; }
    }
}
