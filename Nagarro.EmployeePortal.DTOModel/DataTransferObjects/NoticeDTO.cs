using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.DTOModel
{
    [EntityMapping("Notice", MappingType.TotalExplicit)]
    [ViewModelMapping("Nagarro.EmployeePortal.Web.NoticeModel", MappingType.TotalExplicit)]
    public class NoticeDTO : DTOBase, INoticeDTO
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "Description")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Description")]
        public string Description { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "ExpirationDate")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "ExpirationDate")]
        public DateTime ExpirationDate { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "IsActive")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "IsActive")]
        public bool IsActive { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "NoticeId")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "NoticeId")]
        public int NoticeId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "PostedBy")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "PostedBy")]
        public int PostedBy { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "StartDate")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "StartDate")]
        public DateTime StartDate { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Title")]
        [ViewModelPropertyMapping(MappingDirectionType.Both, "Title")]
        public string Title { get; set; }

        public IEmployeeDTO PostedByEmployee { get; set; }
    }
}
