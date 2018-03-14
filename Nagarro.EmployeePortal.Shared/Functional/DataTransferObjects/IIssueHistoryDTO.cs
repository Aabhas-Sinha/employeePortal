using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public interface IIssueHistoryDTO : IDTO
    {
        int IssueHistoryId { get; set; }
        int IssueId { get; set; }
        string Comments { get; set; }
        int ModifiedBy { get; set; }
        DateTime ModifiedOn { get; set; }
        int? AssignedTo { get; set; }
        int Status { get; set; }
    };
}
