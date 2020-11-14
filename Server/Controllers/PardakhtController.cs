using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines;
using Services;

namespace Server.Controllers
{
    public class PardakhtController : ApiController
    {
        [HttpGet]
        [Route("Pardakht_GetAll")]
        public async Task<IEnumerable<PardakhtBussines>> GetAllAsync() => await PardakhtBussines.GetAllAsync();

        [HttpGet]
        [Route("Pardakht_Get/{guid}")]
        public async Task<PardakhtBussines> GetAsync(Guid guid) => await PardakhtBussines.GetAsync(guid);

        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(PardakhtBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Status) res.AddReturnedValue(await cls.SaveAsync());
                else res.AddReturnedValue(await cls.RemoveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }

    }
}
