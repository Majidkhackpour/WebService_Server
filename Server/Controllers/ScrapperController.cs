using Persistence.Entities;
using Persistence.Model;
using Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Http;
using Server.Models;

namespace Server.Controllers
{
    public class ScrapperController : ApiController
    {
        private ModelContext _db = new ModelContext();

        [HttpPost]
        public Scrapper SaveAsync(Scrapper cls)
        {
            try
            {
                if (cls == null) return null;
                _db.Scrapper.AddOrUpdate(cls);
                _db.SaveChanges();
                return cls;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        [HttpGet]
        [Route("Scrapper_GetAll")]
        public IEnumerable<Scrapper> GetAllAsync()
        {
            try
            {
                var guid = Request.Headers.GetValues("cusGuid").FirstOrDefault();
                var date= Request.Headers.GetValues("date").FirstOrDefault();
                var insertedDate = DateTime.Parse(date);
                if (string.IsNullOrEmpty(guid)) return null;
                var cusGuid = Guid.Parse(guid);
                if (!Assistence.CheckCustomer(cusGuid)) return null;
                insertedDate = new DateTime(insertedDate.Year, insertedDate.Month, insertedDate.Day, 0, 0, 0);
                return _db.Scrapper.Where(q => q.DateM >= insertedDate).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}