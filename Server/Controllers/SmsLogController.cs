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
    public class SmsLogController : ApiController
    {
        private ModelContext db = new ModelContext();

        [HttpGet]
        [Route("SmsLog_GetAll")]
        public IEnumerable<SmsLog> GetAllAsync() => db.SmsLog.ToList();

        [HttpGet]
        [Route("SmsLog_Get/{guid}")]
        public SmsLog GetAsync(Guid guid) => db.SmsLog.FirstOrDefault(q => q.Guid == guid);

        [HttpPost]
        public SmsLog SaveAsync(SmsLog cls)
        {
            try
            {
                var a = db.SmsLog.AsNoTracking()
                    .FirstOrDefault(q => q.Guid == cls.Guid);
                if (a == null) db.SmsLog.Add(cls);
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
        [Route("SmsLog_GetByMessageId/{messageId}")]
        public SmsLog GetAsync(long messageId) => db.SmsLog.FirstOrDefault(q => q.MessageId == messageId);
    }
}
