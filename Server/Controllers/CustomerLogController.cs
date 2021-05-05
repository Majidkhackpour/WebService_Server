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
    public class CustomerLogController : ApiController
    {
        private ModelContext db = new ModelContext();

        [HttpGet]
        [Route("CustomerLog_GetAll")]
        public IEnumerable<CustomerLog> GetAllAsync() => db.CustomerLog.ToList();

        [HttpPost]
        public CustomerLog SaveAsync(CustomerLog cls)
        {
            try
            {
                var a = db.CustomerLog.AsNoTracking()
                    .FirstOrDefault(q => q.Guid == cls.Guid);
                cls.Modified = DateTime.Now;
                if (a == null) db.CustomerLog.Add(cls);
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
        [Route("CustomerLog_GetLog/{parentGuid}")]
        public async Task<CustomerLog> GetAsync(Guid parentGuid) =>
            db.CustomerLog.FirstOrDefault(q => q.Parent == parentGuid);
    }
}
