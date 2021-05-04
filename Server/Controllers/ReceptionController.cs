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
    public class ReceptionController : ApiController
    {
        private ModelContext db = new ModelContext();

        [HttpGet]
        [Route("Reception_GetAll")]
        public IEnumerable<Reception> GetAllAsync() => db.Receptions.ToList();

        [HttpGet]
        [Route("Reception_Get/{guid}")]
        public Reception GetAsync(Guid guid) => db.Receptions.FirstOrDefault(q => q.Guid == guid);

        [HttpPost]
        public Reception SaveAsync(Reception cls)
        {
            try
            {
                var a = db.Receptions.AsNoTracking()
                    .FirstOrDefault(q => q.Guid == cls.Guid);
                if (a == null) db.Receptions.Add(cls);
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
