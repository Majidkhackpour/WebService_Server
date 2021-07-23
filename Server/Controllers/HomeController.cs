using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Server.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Register()
        //{
        //    return View();
        //}
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return PartialView();
        }
    }
}