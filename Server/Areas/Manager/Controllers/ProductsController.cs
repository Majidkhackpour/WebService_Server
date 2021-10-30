using EntityCache.Bussines;
using Persistence.Entities;
using Persistence.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Server.Areas.Manager.Controllers
{
    public class ProductsController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: Manager/Products
        public ActionResult Index()
        {
            return View(db.Products?.Where(q => q.Status)?.OrderBy(q => q.Name)?.ToList());
        }

        // GET: Manager/Products/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return PartialView(product);
        }

        // GET: Manager/Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Code,Price,BckUpPrice,Unit")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.Guid = Guid.NewGuid();
                product.Modified = DateTime.Now;
                product.Status = true;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Manager/Products/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Manager/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Guid,Modified,Status,Name,Code,Price,BckUpPrice,Unit")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.Modified = DateTime.Now;
                product.Status = true;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Manager/Products/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return PartialView(product);
        }

        // POST: Manager/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
            {
                product.Status = false;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public ActionResult Gardesh(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var list = ProductBussines.GetGardesh(id.Value);
            var prd = db.Products.Find(id);
            ViewBag.ProductName = prd != null ? prd.Name : "";
            return View(list);
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
