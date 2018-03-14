using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using Nagarro.EmployeePortal.Web.Shared;

namespace Nagarro.EmployeePortal.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleTable.EnableOptimizations = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableBundling"]);
            BundleConfig.RegisterBundles(BundleTable.Bundles); 
        }
    }
}
