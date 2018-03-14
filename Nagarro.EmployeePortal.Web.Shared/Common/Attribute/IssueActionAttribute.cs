using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.Web.Shared
{
    public class IssueActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var loginUserInfo = SessionStateManager<UserInfo>.Data;
            IIssueFacade issueFacade = (IIssueFacade)FacadeFactory.Instance.Create(FacadeType.IssueManagerFacade);
            OperationResult<IList<IComplexIssueDTO>> issueList = issueFacade.GetAllIssuesByEmployeeId(loginUserInfo.Employee.EmployeeId);

            if (issueList.IsValid())
            {
                int IssueId;
                string issueIdString = filterContext.HttpContext.Request.QueryString["IssueId"];
                Int32.TryParse(issueIdString, out IssueId);

                var finalIssue = (from issue in issueList.Data where (issue.IssueId == IssueId) select issue).SingleOrDefault();

                if (finalIssue != null)
                {
                    base.OnActionExecuting(filterContext);
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Account/UnAuthorizeAccess");
                }

            }
        }
    }
}
