using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public interface IIssueDAC : IDataAccessComponent
    {
        IList<IComplexIssueDTO> GetAllIssuesByEmployeeId(int employeeId);
        IIssueDTO CreateIssue(IIssueDTO issueDTO);
        IIssueDTO UpdateIssue(IIssueDTO issueDTO);
        bool DeleteIssue(int issueId);
        IList<IComplexIssueDTO> GetAllActiveIssues();
        IIssueHistoryDTO UpdateIssueByAdmin(IIssueHistoryDTO issueHistoryDTO);
        IIssueDTO GetIssue(int issueId);
    }
}
