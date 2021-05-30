using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace Server.Controllers
{
    public class CustomerAndroidController : ApiController
    {
        private ModelContext db = new ModelContext();

        [HttpGet]
        [Route("CusAndroid_GetAll/{cusGuid}")]
        public IEnumerable<Androids> GetAllAsync(Guid cusGuid) => db.Androids.Where(q => q.CustomerGuid == cusGuid).ToList();

        [HttpGet]
        [Route("CusAndroid_Get/{guid}")]
        public Androids GetAsync(Guid guid) => db.Androids.FirstOrDefault(q => q.Guid == guid);

        [HttpPost]
        public Androids SaveAsync(Androids cls)
        {
            try
            {
                cls.Modified = DateTime.Now;
                var a = db.Androids.AsNoTracking().FirstOrDefault(q => q.Guid == cls.Guid);
                if (a == null) db.Androids.Add(cls);
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