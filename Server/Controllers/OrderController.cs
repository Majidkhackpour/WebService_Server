using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines;
using Services;

namespace Server.Controllers
{
    public class OrderController : ApiController
    {
        [HttpGet]
        [Route("Order_GetAll")]
        public async Task<IEnumerable<OrderBussines>> GetAllAsync() => await OrderBussines.GetAllAsync();

        [HttpGet]
        [Route("Order_Get/{guid}")]
        public async Task<OrderBussines> GetAsync(Guid guid) => await OrderBussines.GetAsync(guid);

        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(OrderBussines cls)
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

        [HttpGet]
        [Route("Order_NextCode")]
        public async Task<string> NextCodeAsync() => await OrderBussines.NextCodeAsync();
    }
}
