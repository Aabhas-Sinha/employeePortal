using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public interface IIssueDTO : IDTO
    {
        int IssueId { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        int PostedBy { get; set; }
        int Priority { get; set; }
        bool IsActive { get; set; }
        IList<IComplexIssueHistoryDTO> IssueHistories { get; set; }
        IEmployeeDTO EmployeeDTO { get; set; }
    }
}
