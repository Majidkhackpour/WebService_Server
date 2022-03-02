using EntityCache.Bussines;
using Services.LkSerial;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using EntityCache.ViewModels;
using Services;

namespace Server.Areas.Manager.Controllers
{
    public class CustomersController : Controller
    {
        public async Task<ActionResult> Index()
        {
            try
            {
                var list = await CustomerBussines.GetAllAsync();
                return View(list);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return View();
        }
        public async Task<ActionResult> Details(Guid? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var customers = await CustomerBussines.GetAsync(id.Value);
                if (customers == null || customers.Guid == Guid.Empty)
                    return HttpNotFound();

                return PartialView(customers);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return PartialView();
        }
        public async Task<ActionResult> Create()
        {
            try
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
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,CompanyName,NationalCode,PostalCode,AppSerial,Address,Tell1,Tell2,Tell3,Tell4,Email,HardSerial,SiteUrl,Address,Description,CustomerSerial")] CustomerBussines customers)
        {
            try
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
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(Guid? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var customers = await CustomerBussines.GetAsync(id.Value, true);
                if (customers == null || customers.Guid == Guid.Empty)
                    return HttpNotFound();
                return View(customers);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return View();
        }
        public async Task<ActionResult> AppSerial(Guid? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var customers = await CustomerBussines.GetAsync(id.Value);
                if (customers == null || customers.Guid == Guid.Empty)
                    return HttpNotFound();
                return PartialView(customers);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Guid,Modified,Status,Name,CompanyName,NationalCode,AppSerial,Address,PostalCode,Tell1,Tell2,Tell3,Tell4,Email,Description,ExpireDate,UserGuid,Account,UserName,Password,SiteUrl,HardSerial,LkSerial,isBlock,isWebServiceBlock,CustomerSerial")] CustomerBussines customers, HttpPostAttribute item)
        {
            try
            {
                if (!ModelState.IsValid) return View(customers);
                await customers.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(Guid? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var customers = await CustomerBussines.GetAsync(id.Value);
                if (customers == null || customers.Guid == Guid.Empty)
                    return HttpNotFound();
                return PartialView(customers);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return PartialView();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                var customers = await CustomerBussines.GetAsync(id);
                customers.Status = false;
                await customers.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> ActivationCode(Guid? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var item = await ActivatioCodeViewModel.GenerateAsync(id.Value);
                return View(item);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ActivationCode([Bind(Include = "CustomerGuid,AppSerial,HardSerial,CustomerName,ExpireDateSh,Term,Description,ActivationCode")] ActivatioCodeViewModel activationModel)
        {
            var a = activationModel;
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<ActionResult> GeneratActivationCode(ActivatioCodeViewModel id)
        {
            id.ActivationCode = GenerateActivationCodeServer.ActivationCode(id.Term, id.HardSerial);
            return PartialView(id);
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
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var customers = await CustomerBussines.GetAsync(id.Value);
                if (customers == null || customers.Guid == Guid.Empty)
                    return HttpNotFound();
                return PartialView(customers);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> isBlock(Guid id)
        {
            try
            {
                var customers = await CustomerBussines.GetAsync(id);
                customers.isBlock = !customers.isBlock;
                await customers.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> isWebServiceBlock(Guid? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var customers = await CustomerBussines.GetAsync(id.Value);
                if (customers == null || customers.Guid == Guid.Empty)
                    return HttpNotFound();
                return PartialView(customers);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> isWebServiceBlock(Guid id)
        {
            try
            {
                var customers = await CustomerBussines.GetAsync(id);
                customers.isWebServiceBlock = !customers.isWebServiceBlock;
                await customers.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return RedirectToAction("Index");
        }
    }
}
