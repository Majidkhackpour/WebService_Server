using EntityCache.Bussines;
using Services.LkSerial;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using EntityCache.ViewModels;

namespace Server.Areas.Manager.Controllers
{
    public class CustomersController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var list = await CustomerBussines.GetAllAsync();
            return View(list);
        }
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customers = await CustomerBussines.GetAsync(id.Value);
            if (customers == null || customers.Guid == Guid.Empty)
                return HttpNotFound();

            return PartialView(customers);
        }
        public async Task<ActionResult> Create()
        {
            var cus = new CustomerBussines();
            var allProduct = await ProductBussines.GetAllAsync();
            foreach (var prd in allProduct)
            {
                cus.CustomerSerial.Add(new CustomerSerialViewModel()
                {
                    IsChecked = false,
                    ProductCode = prd.Code,
                    ProductGuid = prd.Guid,
                    ProductName = prd.Name
                });
            }
            return View(cus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,CompanyName,NationalCode,PostalCode,AppSerial,Address,Tell1,Tell2,Tell3,Tell4,Email,HardSerial,SiteUrl,Address,Description,CustomerSerial")] CustomerBussines customers)
        {
            if (!ModelState.IsValid) return View(customers);
            customers.Guid = Guid.NewGuid();
            customers.Modified = DateTime.Now;
            customers.Status = true;
            customers.Account = 0;
            customers.CreateDate = DateTime.Now;
            customers.ExpireDate = DateTime.Now.AddYears(1);
            customers.isBlock = false;
            customers.isWebServiceBlock = false;
            await customers.SaveAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var customers = await CustomerBussines.GetAsync(id.Value, true);
            if (customers == null || customers.Guid == Guid.Empty)
                return HttpNotFound();
            return View(customers);
        }
        public async Task<ActionResult> AppSerial(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var customers = await CustomerBussines.GetAsync(id.Value);
            if (customers == null || customers.Guid == Guid.Empty)
                return HttpNotFound();
            return PartialView(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Guid,Modified,Status,Name,CompanyName,NationalCode,AppSerial,Address,PostalCode,Tell1,Tell2,Tell3,Tell4,Email,Description,ExpireDate,UserGuid,Account,UserName,Password,SiteUrl,HardSerial,LkSerial,isBlock,isWebServiceBlock,CustomerSerial")] CustomerBussines customers, HttpPostAttribute item)
        {
            if (!ModelState.IsValid) return View(customers);
            await customers.SaveAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var customers = await CustomerBussines.GetAsync(id.Value);
            if (customers == null || customers.Guid == Guid.Empty)
                return HttpNotFound();
            return PartialView(customers);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            //Customers customers = db.Customers.Find(id);
            //db.Customers.Remove(customers);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> ActivationCode(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var customers = await CustomerBussines.GetAsync(id.Value);
            if (customers == null || customers.Guid == Guid.Empty)
                return HttpNotFound();
            return View(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ActivationCode(Guid id)
        {
            var customers = await CustomerBussines.GetAsync(id);
            if (ModelState.IsValid)
            {
                var a = customers.Guid;
                var b = customers.UserGuid;
                var c = customers.Name;
                var d = customers.ExpireDateSh;
                var e = customers.AppSerial;
                var f = customers.UserName;
                return RedirectToAction("Index");
            }
            return View(customers);
        }
        public async Task<ActionResult> GeneratActivationCode(Guid id, int month)
        {
            var customer = await CustomerBussines.GetAsync(id);
            if (ModelState.IsValid && customer != null && customer.Guid != Guid.Empty)
            {
                var activecode = GenerateActivationCodeServer.ActivationCode(month, customer.HardSerial);
            }
            return View();
        }
        public async Task<ActionResult> ActivationSmsCode(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var customers = await CustomerBussines.GetAsync(id.Value);
            if (customers == null || customers.Guid == Guid.Empty)
                return HttpNotFound();
            return PartialView(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ActivationSmsCode(Guid id)
        {
            var customers = await CustomerBussines.GetAsync(id);
            if (!ModelState.IsValid) return View(customers);
            var a = customers.Guid;
            var b = customers.UserGuid;
            var c = customers.Name;
            var d = customers.ExpireDateSh;
            var e = customers.AppSerial;
            var f = customers.UserName;
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> isBlock(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var customers = await CustomerBussines.GetAsync(id.Value);
            if (customers == null || customers.Guid == Guid.Empty)
                return HttpNotFound();
            return PartialView(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> isBlock(Guid id)
        {
            var customers = await CustomerBussines.GetAsync(id);
            customers.isBlock = !customers.isBlock;
            await customers.SaveAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> isWebServiceBlock(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var customers = await CustomerBussines.GetAsync(id.Value);
            if (customers == null || customers.Guid == Guid.Empty)
                return HttpNotFound();
            return PartialView(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> isWebServiceBlock(Guid id)
        {
            var customers = await CustomerBussines.GetAsync(id);
            customers.isWebServiceBlock = !customers.isWebServiceBlock;
            await customers.SaveAsync();
            return RedirectToAction("Index");
        }
    }
}
