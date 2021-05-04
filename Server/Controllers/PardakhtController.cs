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
    public class PardakhtController : ApiController
    {
        private ModelContext db = new ModelContext();

        [HttpGet]
        [Route("Pardakht_GetAll")]
        public IEnumerable<Pardakht> GetAllAsync() => db.Pardakht.ToList();

        [HttpGet]
        [Route("Pardakht_Get/{guid}")]
        public Pardakht GetAsync(Guid guid) => db.Pardakht.FirstOrDefault(q => q.Guid == guid);

        [HttpPost]
        public Pardakht SaveAsync(Pardakht cls)
        {
            try
            {
                var a = db.Pardakht.AsNoTracking()
                    .FirstOrDefault(q => q.Guid == cls.Guid);
                if (a == null) db.Pardakht.Add(cls);
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
