using Persistence.Entities.Building;
using Persistence.Model;
using Server.Models;
using Services;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Http;

namespace Server.Controllers
{
    public class MoeinController : ApiController
    {
        private ModelContext db = new ModelContext();

        [System.Web.Http.HttpPost]
        public Moein SaveAsync(Moein cls)
        {
            try
            {
                var headers = Request.Headers?.ToList();
                if (headers == null || headers.Count <= 0) return null;
                var guid = Request.Headers.GetValues("cusGuid").FirstOrDefault();
                if (string.IsNullOrEmpty(guid)) return null;
                var cusGuid = Guid.Parse(guid);
                if (!Assistence.CheckCustomer(cusGuid)) return null;
                db.Moein.AddOrUpdate(cls);
                db.SaveChanges();
                Assistence.SaveLog(cusGuid, cls.Guid, EnTemp.Moein);
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