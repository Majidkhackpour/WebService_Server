using EntityCache.ViewModels;
using Persistence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Server.Controllers
{
    public class HomeController : Controller
    {
        ModelContext db = new ModelContext();
        // GET: Home
        public ActionResult Index()
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

        [Route("Login")]
        [HttpPost]
        public ActionResult Login(FormCollection form, loginViewModel Login, string ReturnUrl = "/arad-manager")
        {
            if (ModelState.IsValid)
            {
                string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Login.Password, "MD5");
                var user = db.Users.SingleOrDefault(u => u.Email == Login.Email && u.Password == hashPassword);
                if (user != null)
                {
                    if (user.IsBlock == false)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, Login.RememberMe);
                        return Redirect(ReturnUrl);
                    }
                    else 
                    {
                        ModelState.AddModelError("Email", "کاربر گرامی حساب کاربری شما توسط سیستم مسدود شده است");
                        //ViewBag.IsBlock = true;
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "کاربری با اطلاعات وارد شده یافت نشد");
                }
            }

            return View(Login); ;
        }

        [Route("logOut")]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        public ActionResult Menu()
        {
            return PartialView();
        }


    }
}