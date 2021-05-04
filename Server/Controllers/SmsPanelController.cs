using Persistence.Entities;
using Persistence.Model;
using Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Server.Controllers
{
    public class SmsPanelController : ApiController
    {
        private ModelContext db = new ModelContext();

        [HttpGet]
        [Route("SmsPanel_GetAll")]
        public IEnumerable<SmsPanels> GetAllAsync() => db.SmsPanels.ToList();

        [HttpGet]
        [Route("SmsPanel_Get/{guid}")]
        public SmsPanels GetAsync(Guid guid) => db.SmsPanels.FirstOrDefault(q => q.Guid == guid);

        [HttpPost]
        public SmsPanels SaveAsync(SmsPanels cls)
        {
            try
            {
                var a = db.SmsPanels.AsNoTracking()
                    .FirstOrDefault(q => q.Guid == cls.Guid);
                if (a == null) db.SmsPanels.Add(cls);
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

        [HttpGet]
        [Route("SmsPanel_GetCurrent")]
        public SmsPanels GetCurrentAsync() => db.SmsPanels.FirstOrDefault(q => q.IsCurrent);
    }
}
