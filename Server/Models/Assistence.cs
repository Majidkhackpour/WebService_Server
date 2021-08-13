using System;
using System.Linq;
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
    }
}