using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Persistence.Entities.Building;
using Persistence.Model;
using Services;

namespace Server.Controllers
{
    public class BuildingPardakhtController : ApiController
    {
        private ModelContext db = new ModelContext();

        [System.Web.Http.HttpPost]
        public BuildingPardakht SaveAsync(BuildingPardakht cls)
        {
            try
            {
                var cust = db.Customers.AsNoTracking().FirstOrDefault(q => q.HardSerial == cls.HardSerial);
                cls.CustomerGuid = cust?.Guid ?? Guid.Empty;
                var a = db.BuildingPardakht.AsNoTracking()
                    .FirstOrDefault(q => q.Guid == cls.Guid && q.CustomerGuid == cust.Guid);
                if (a == null) db.BuildingPardakht.Add(cls);
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