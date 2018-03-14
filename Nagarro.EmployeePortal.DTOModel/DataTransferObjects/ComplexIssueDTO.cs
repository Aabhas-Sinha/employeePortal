using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.DTOModel
{
    [EntityMapping("Nagarro.EmployeePortal.EntityDataModel.EntityModel.GetAllIssuesByEmployeeId_Result", MappingType.TotalExplicit)]
    [ViewModelMapping("Nagarro.EmployeePortal.Web.ComplexIssue", MappingType.TotalExplicit)]
    public class ComplexIssueDTO : DTOBase, IComplexIssueDTO
    {
        public ComplexIssueDTO() : base(DTOType.ComplexIssueDTO)
        {

        }

        [EntityPropertyMapping(MappingDirectionType.DTOFromEntity, "AssignedTo")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "AssignedTo")]
        public int? AssignedTo { get; set; }

        [EntityPropertyMapping(MappingDirectionType.DTOFromEntity, "AssignedToName")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "AssignedToName")]
        public string AssignedToName { get; set; }

        [EntityPropertyMapping(MappingDirectionType.DTOFromEntity, "Description")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Description")]
        public string Description { get; set; }

        [EntityPropertyMapping(MappingDirectionType.DTOFromEntity, "IsActive")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "IsActive")]
        public bool IsActive { get; set; }

        [EntityPropertyMapping(MappingDirectionType.DTOFromEntity, "IssueId")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "IssueId")]
        public int IssueId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.DTOFromEntity, "PostedBy")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "PostedBy")]
        public int PostedBy { get; set; }

        [EntityPropertyMapping(MappingDirectionType.DTOFromEntity, "PostedByName")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "PostedByName")]
        public string PostedByName { get; set; }

        [EntityPropertyMapping(MappingDirectionType.DTOFromEntity, "Priority")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Priority")]
        public int Priority { get; set; }

        [EntityPropertyMapping(MappingDirectionType.DTOFromEntity, "Status")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Status")]
        public int Status { get; set; }

        [EntityPropertyMapping(MappingDirectionType.DTOFromEntity, "Title")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Title")]
        public string Title { get; set; }
    }
}
