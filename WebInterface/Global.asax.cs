using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using log4net;
using log4net.Config;

namespace WebInterface
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(WebApiApplication));

        protected void Application_Start()
        {
            XmlConfigurator.Configure(new FileInfo(string.Format(@"{0}\log4net.config", Server.MapPath("~/"))));
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Error += WebApiApplication_Error;
        }

        private void WebApiApplication_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                _log.Error("Exception", ex);
            }
        }
    }
}
