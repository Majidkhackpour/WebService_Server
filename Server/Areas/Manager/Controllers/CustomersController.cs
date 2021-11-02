using Persistence.Entities;
using Persistence.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Server.Areas.Manager.Controllers
{
    public class CustomersController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: Manager/Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Manager/Customers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return PartialView(customers);
        }

        // GET: Manager/Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,CompanyName,NationalCode,PostalCode,AppSerial,Address,Tell1,Tell2,Tell3,Tell4,Email,HardSerial,SiteUrl,Address,Description")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                customers.Guid = Guid.NewGuid();
                customers.Modified = DateTime.Now;
                customers.Status = true;
                customers.Account = 0;
                customers.CreateDate = DateTime.Now;
                customers.ExpireDate=DateTime.Now.AddYears(1);
                customers.isBlock = false;
                customers.isWebServiceBlock = false;
                db.Customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customers);
        }

        // GET: Manager/Customers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Manager/Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Guid,Modified,Status,CreateDate,Name,CompanyName,NationalCode,AppSerial,Address,PostalCode,Tell1,Tell2,Tell3,Tell4,Email,Description,ExpireDate,UserGuid,Account,UserName,Password,SiteUrl,HardSerial,LkSerial,isBlock,isWebServiceBlock")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customers);
        }

        // GET: Manager/Customers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Manager/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Customers customers = db.Customers.Find(id);
            db.Customers.Remove(customers);
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
