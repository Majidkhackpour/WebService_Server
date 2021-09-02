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
        [Route("Scrapper_GetAll/{date}")]
        public IEnumerable<Scrapper> GetAllAsync(DateTime? date)
        {
            try
            {
                var guid = Request.Headers.GetValues("cusGuid").FirstOrDefault();
                if (string.IsNullOrEmpty(guid)) return null;
                var cusGuid = Guid.Parse(guid);
                if (!Assistence.CheckCustomer(cusGuid)) return null;
                if (date == null) date = DateTime.Now.AddDays(-7);
                date = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, 0, 0, 0);
                return _db.Scrapper.Where(q => q.DateM >= date);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}