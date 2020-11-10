using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines;
using Services;

namespace Server.Controllers
{
    public class SmsLogController : ApiController
    {
        [HttpGet]
        [Route("SmsLog_GetAll")]
        public async Task<IEnumerable<SmsLogBussines>> GetAllAsync() => await SmsLogBussines.GetAllAsync();
        [HttpGet]
        [Route("SmsLog_Get/{guid}")]
        public async Task<SmsLogBussines> GetAsync(Guid guid) => await SmsLogBussines.GetAsync(guid);
        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(SmsLogBussines cls) => await cls.SaveAsync();

        [HttpGet]
        [Route("SmsLog_GetByMessageId/{messageId}")]
        public async Task<SmsLogBussines> GetAsync(long messageId) => await SmsLogBussines.GetAsync(messageId);
    }
}
