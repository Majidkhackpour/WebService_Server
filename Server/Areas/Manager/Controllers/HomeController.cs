using Persistence.Entities;
using Persistence.Model;
using Services;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Server.Areas.Manager.Controllers
{
    public class HomeController : Controller
    {
        ModelContext db = new ModelContext();
        // GET: Manager/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewErrors()
        {
            return View(db.ErrorLog.OrderByDescending(q => q.Date)?.ToList());
        }

        // GET: Manager/Users/Details/5
        public ActionResult Details(Guid? id)
        {
            ErrorLog errorLog = null;
            try
            {
                errorLog = db.ErrorLog.Find(id);
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                if (errorLog == null)
                    return HttpNotFound();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return View(errorLog);
        }

        public ActionResult Delete(Guid? id)
        {
            ErrorLog errorLog = db.ErrorLog.Find(id);
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (errorLog == null)
                {
                    return HttpNotFound();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return View(errorLog);
        }

        // POST: Manager/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                ErrorLog errorLog = db.ErrorLog.Find(id);
                db.ErrorLog.Remove(errorLog);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return RedirectToAction("ViewErrors");
        }

        public ActionResult CustomerDetail(Guid id)
        {
            var h = db.ErrorLog.FirstOrDefault(a => a.Guid == id);
            var cus = db.Customers.FirstOrDefault(a => a.HardSerial == h.HardSerial);
            return PartialView(cus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}