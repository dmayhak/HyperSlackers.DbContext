using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using HyperSlackers.DbContext.Demo.Models;

namespace HyperSlackers.DbContext.Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // DRM Added
            // Initialize the DB
            // Not the way it's normally done, but it's just a demo...  :-)
            var context = ApplicationDbContext.Create();
            //bool auditingEnabled = context.AuditingEnabled; // temporarily disable auditing
            //context.AuditingEnabled = false;
            var hosts = context.Hosts.ToList();
            //context.AuditingEnabled = auditingEnabled;
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                //here we can subscribe user to a role via Roles.AddUserToRole()
            }
        }
    }
}
