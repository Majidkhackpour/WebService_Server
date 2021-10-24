using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Http;
using Persistence.Entities.Building;
using Persistence.Model;
using Server.Models;
using Services;

namespace Server.Controllers
{
    public class BuildingNoteController : ApiController
    {
        private ModelContext db = new ModelContext();

        [HttpPost]
        public BuildingNote SaveAsync(BuildingNote cls)
        {
            try
            {
                cls.Modified = DateTime.Now;
                var headers = Request.Headers?.ToList();
                if (headers == null || headers.Count <= 0) return null;
                var guid = Request.Headers.GetValues("cusGuid").FirstOrDefault();
                if (string.IsNullOrEmpty(guid)) return null;
                var cusGuid = Guid.Parse(guid);
                if (!Assistence.CheckCustomer(cusGuid)) return null;
                db.BuildingNote.AddOrUpdate(cls);
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