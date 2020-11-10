using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines;
using Services;

namespace Server.Controllers
{
    public class SmsPanelController : ApiController
    {
        [HttpGet]
        [Route("SmsPanel_GetAll")]
        public async Task<IEnumerable<SmsPanelsBussines>> GetAllAsync() => await SmsPanelsBussines.GetAllAsync();
        [HttpGet]
        [Route("SmsPanel_Get/{guid}")]
        public async Task<SmsPanelsBussines> GetAsync(Guid guid) => await SmsPanelsBussines.GetAsync(guid);
        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(SmsPanelsBussines cls) => await cls.SaveAsync();
        [HttpGet]
        [Route("SmsPanel_GetCurrent")]
        public async Task<SmsPanelsBussines> GetCurrentAsync() => await SmsPanelsBussines.GetCurrentAsync();
    }
}
