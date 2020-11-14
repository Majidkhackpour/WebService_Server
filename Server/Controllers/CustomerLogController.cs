using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines;
using Services;

namespace Server.Controllers
{
    public class CustomerLogController : ApiController
    {
        [HttpGet]
        [Route("CustomerLog_GetAll")]
        public async Task<IEnumerable<CustomerLogBussines>> GetAllAsync() =>
            await CustomerLogBussines.GetAllAsync();
        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(CustomerLogBussines cls) => await cls.SaveAsync();


        [HttpGet]
        [Route("CustomerLog_GetLog/{parentGuid}")]
        public async Task<CustomerLogBussines> GetAsync(Guid parentGuid) => await CustomerLogBussines.GetLogByParentAsync(parentGuid);
    }
}
