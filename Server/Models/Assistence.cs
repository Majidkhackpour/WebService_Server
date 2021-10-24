using System;
using System.Linq;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace Server.Models
{
    public class Assistence
    {
        public static bool CheckCustomer(Guid cusGuid)
        {
            try
            {
                var db = new ModelContext();
                return db.Customers.AsNoTracking().Any(q => q.Guid == cusGuid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        public static bool SaveLog(Guid cusGuid, Guid objectGuid, EnTemp tmp)
        {
            try
            {
                var db = new ModelContext();
                var log = new SyncedData()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    CustomerGuid = cusGuid,
                    Type = tmp,
                    ObjectGuid = objectGuid
                };
                db.SyncedData.Add(log);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
    }
}