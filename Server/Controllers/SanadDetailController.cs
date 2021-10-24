using Persistence.Entities.Building;
using Persistence.Model;
using Services;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Http;
using Server.Models;

namespace Server.Controllers
{
    public class SanadDetailController : ApiController
    {
        private ModelContext db = new ModelContext();

        [HttpPost]
        public SanadDetail SaveAsync(SanadDetail cls)
        {
            try
            {
                var headers = Request.Headers?.ToList();
                if (headers == null || headers.Count <= 0) return null;
                var guid = Request.Headers.GetValues("cusGuid").FirstOrDefault();
                if (string.IsNullOrEmpty(guid)) return null;
                var cusGuid = Guid.Parse(guid);
                if (!Assistence.CheckCustomer(cusGuid)) return null;
                db.SanadDetail.AddOrUpdate(cls);
                db.SaveChanges();
                return cls;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}