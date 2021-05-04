using Persistence.Entities.Building;
using Persistence.Model;
using Services;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Server.Controllers
{
    public class BuildingPhoneBookController : ApiController
    {
        private ModelContext db = new ModelContext();

        [HttpPost]
        public BuildingPhoneBook SaveAsync(BuildingPhoneBook cls)
        {
            try
            {
                var a = db.BuildingPhoneBooks.AsNoTracking()
                    .FirstOrDefault(q => q.Guid == cls.Guid && q.HardSerial == cls.HardSerial);
                if (a == null) db.BuildingPhoneBooks.Add(cls);
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
