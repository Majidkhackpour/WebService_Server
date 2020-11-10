using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines;
using Services;

namespace Server.Controllers
{
    public class SafeBoxController : ApiController
    {
        [HttpGet]
        [Route("SafeBox_GetAll")]
        public async Task<IEnumerable<SafeBoxBussines>> GetAllAsync() => await SafeBoxBussines.GetAllAsync();
        [HttpGet]
        [Route("SafeBox_Get/{guid}")]
        public async Task<SafeBoxBussines> GetAsync(Guid guid) => await SafeBoxBussines.GetAsync(guid);
        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(SafeBoxBussines cls) => await cls.SaveAsync();
    }
}
