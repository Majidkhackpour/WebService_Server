using Persistence.Entities;
using Persistence.Model;
using Services;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace Server.Areas.Manager.Controllers
{
    public class UsersController : Controller
    {
        ModelContext db = new ModelContext();

        // GET: Manager/Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Manager/Users/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return PartialView(users);
        }

        // GET: Manager/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Status,Name,UserName,Password,Mobile,Email,IsBlock,Type")] Users users)
        {
            try
            {
                if (users.Guid == Guid.Empty) users.Guid = Guid.NewGuid();
                users.Modified = DateTime.Now;
                if (ModelState.IsValid)
                {
                    users.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(users.Password, "MD5");
                    db.Users.Add(users);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return View(users);
        }

        // GET: Manager/Users/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Manager/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Guid,Modified,Status,Name,UserName,Password,Mobile,Email,IsBlock,Type")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Manager/Users/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return PartialView(users);
            //Users users = db.Users.Find(id);
            //db.Users.Remove(users);
            //db.SaveChanges();
        }

        // POST: Manager/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Users users = db.Users.Find(id);
            users.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
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
