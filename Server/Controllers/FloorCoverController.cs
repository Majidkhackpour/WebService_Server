﻿using Persistence.Entities.Building;
using Persistence.Model;
using Services;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Server.Controllers
{
    public class FloorCoverController : ApiController
    {
        private ModelContext db = new ModelContext();

        [HttpPost]
        public FloorCover SaveAsync(FloorCover cls)
        {
            try
            {
                var cust = db.Customers.AsNoTracking().FirstOrDefault(q => q.HardSerial == cls.HardSerial);
                cls.CustomerGuid = cust?.Guid ?? Guid.Empty;
                var a = db.FloorCovers.AsNoTracking()
                    .FirstOrDefault(q => q.Guid == cls.Guid && q.CustomerGuid == cust.Guid);
                if (a == null) db.FloorCovers.Add(cls);
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
