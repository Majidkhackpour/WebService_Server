using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Services;

namespace Server
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            try
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
                routes.MapMvcAttributeRoutes();
                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                    namespaces: new[] { "Server.Controllers" }
                );
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
