using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using Services;

namespace Server
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            EntityCache.Assistence.ClsCache.Init();
            ErrorHandler.AddHandler("9.9.9.9", ENSource.Server, "", "");
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}