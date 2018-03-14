using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public interface IIssueBDC : IBusinessDomainComponent
    {
        OperationResult<IList<IComplexIssueDTO>> GetAllIssuesByEmployeeId(int employeeId);
        OperationResult<IIssueDTO> CreateIssue(IIssueDTO issueDTO);
        OperationResult<IIssueDTO> UpdateIssue(IIssueDTO issueDTO);
        OperationResult<bool> DeleteIssue(int issueId);
        OperationResult<IList<IComplexIssueDTO>> GetAllActiveIssues();
        OperationResult<IIssueHistoryDTO> UpdateIssueByAdmin(IIssueHistoryDTO issueHistoryDTO);
        OperationResult<IIssueDTO> GetIssue(int issueId);
    }
}
