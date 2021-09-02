using System.Web.Mvc;

namespace Server.Areas.Manager
{
    public class ManagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Manager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Arad-Manager_default",
                "Arad-Manager/{controller}/{action}/{id}",
                new {Controller="Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}