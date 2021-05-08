using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Persistence.Entities.Building;
using Persistence.Model;
using Services;

namespace Server.Controllers
{
    public class SanadController : Controller
    {
        private ModelContext db = new ModelContext();

        [System.Web.Http.HttpPost]
        public Sanad SaveAsync(Sanad cls)
        {
            try
            {
                var cust = db.Customers.AsNoTracking().FirstOrDefault(q => q.HardSerial == cls.HardSerial);
                cls.CustomerGuid = cust?.Guid ?? Guid.Empty;
                var a = db.Sanad.AsNoTracking()
                    .FirstOrDefault(q => q.Guid == cls.Guid && q.CustomerGuid == cust.Guid);
                if (a == null) db.Sanad.Add(cls);
                else db.Entry(cls).State = EntityState.Modified;
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