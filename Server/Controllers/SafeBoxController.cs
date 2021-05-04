using Persistence.Entities;
using Persistence.Model;
using Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Server.Controllers
{
    public class SafeBoxController : ApiController
    {
        private ModelContext db = new ModelContext();

        [HttpGet]
        [Route("SafeBox_GetAll")]
        public IEnumerable<SafeBox> GetAllAsync() => db.SafeBoxe.ToList();

        [HttpGet]
        [Route("SafeBox_Get/{guid}")]
        public SafeBox GetAsync(Guid guid) => db.SafeBoxe.FirstOrDefault(q => q.Guid == guid);

        [HttpPost]
        public SafeBox SaveAsync(SafeBox cls)
        {
            try
            {
                var a = db.SafeBoxe.AsNoTracking()
                    .FirstOrDefault(q => q.Guid == cls.Guid );
                if (a == null) db.SafeBoxe.Add(cls);
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
        [Route("SafeBox_GetByName/{name}")]
        public SafeBox GetAsync(string name) => db.SafeBoxe.FirstOrDefault(q => q.Name == name);
    }
}
