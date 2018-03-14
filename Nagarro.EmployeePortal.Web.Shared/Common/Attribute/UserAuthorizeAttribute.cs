using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Security.Principal;

namespace Nagarro.EmployeePortal.Web.Shared
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method|AttributeTargets.Property,AllowMultiple =false)]
    public sealed class UserAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                
                var loginUserInfo = SessionStateManager<UserInfo>.Data;
                if(loginUserInfo.Employee != null)
                {
                    if (loginUserInfo.IsAdmin)
                    {
                        loginUserInfo.Role = "Admin";
                    }
                    else
                    {
                        loginUserInfo.Role = "NonAdmin";
                    }
                    string[] roleArray = new string[] { loginUserInfo.Role };

                    filterContext.HttpContext.User = new GenericPrincipal(new GenericIdentity(loginUserInfo.Employee.Email, "forms"), roleArray);
                    base.OnAuthorization(filterContext);
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Account/Login");
                }
        
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Account/UnAuthorizeAccess");
        }
    }
}
