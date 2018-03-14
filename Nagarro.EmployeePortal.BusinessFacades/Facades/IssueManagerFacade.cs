using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.BusinessFacades
{
    public class IssueManagerFacade : FacadeBase, IIssueFacade
    {
        public IssueManagerFacade(): base(FacadeType.IssueManagerFacade)
        {

        }

        public OperationResult<IIssueDTO> CreateIssue(IIssueDTO issueDTO)
        {
            IIssueBDC issueBDC = (IIssueBDC)BDCFactory.Instance.Create(BDCType.IssueManagerBDC);
            return issueBDC.CreateIssue(issueDTO);
        }

        public OperationResult<bool> DeleteIssue(int issueId)
        {
            IIssueBDC issueBDC = (IIssueBDC)BDCFactory.Instance.Create(BDCType.IssueManagerBDC);
            return issueBDC.DeleteIssue(issueId);
        }

        public OperationResult<IList<IComplexIssueDTO>> GetAllActiveIssues()
        {
            IIssueBDC issueBDC = (IIssueBDC)BDCFactory.Instance.Create(BDCType.IssueManagerBDC);
            return issueBDC.GetAllActiveIssues();
        }

        public OperationResult<IList<IComplexIssueDTO>> GetAllIssuesByEmployeeId(int employeeId)
        {
            IIssueBDC issueBDC = (IIssueBDC)BDCFactory.Instance.Create(BDCType.IssueManagerBDC);
            return issueBDC.GetAllIssuesByEmployeeId(employeeId);
        }

        public OperationResult<IIssueDTO> GetIssue(int issueId)
        {
            IIssueBDC issueBDC = (IIssueBDC)BDCFactory.Instance.Create(BDCType.IssueManagerBDC);
            return issueBDC.GetIssue(issueId);
        }

        public OperationResult<IIssueDTO> UpdateIssue(IIssueDTO issueDTO)
        {
            IIssueBDC issueBDC = (IIssueBDC)BDCFactory.Instance.Create(BDCType.IssueManagerBDC);
            return issueBDC.UpdateIssue(issueDTO);
        }

        public OperationResult<IIssueHistoryDTO> UpdateIssueByAdmin(IIssueHistoryDTO issueHistoryDTO)
        {
            IIssueBDC issueBDC = (IIssueBDC)BDCFactory.Instance.Create(BDCType.IssueManagerBDC);
            return issueBDC.UpdateIssueByAdmin(issueHistoryDTO);
        }
    }
}
