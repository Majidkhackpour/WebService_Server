﻿using Persistence.Entities.Building;
using Persistence.Model;
using Services;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Server.Controllers
{
    public class KitchenServiceController : ApiController
    {
        private ModelContext db = new ModelContext();

        [HttpPost]
        public KitchenService SaveAsync(KitchenService cls)
        {
            try
            {
                var cust = db.Customers.AsNoTracking().FirstOrDefault(q => q.HardSerial == cls.HardSerial);
                cls.CustomerGuid = cust?.Guid ?? Guid.Empty;
                var a = db.KitchenServices.AsNoTracking()
                    .FirstOrDefault(q => q.Guid == cls.Guid && q.CustomerGuid == cust.Guid);
                if (a == null) db.KitchenServices.Add(cls);
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
