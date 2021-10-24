using System.Web.Mvc;

namespace Server.Controllers
{
    public class ManageErrorsController : Controller
    {
        [Route("404")]
        public ActionResult ManageErrors()
        {
            return View();
        }
    }
}