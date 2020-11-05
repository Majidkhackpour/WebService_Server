using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines;
using Services;

namespace Server.Controllers
{
    public class CustomersController : ApiController
    {
        [HttpGet]
        [Route("Customer_GetAll")]
        public async Task<IEnumerable<CustomerBussines>> GetAllAsync() => await CustomerBussines.GetAllAsync();
        [HttpGet]
        [Route("Customer_Get/{guid}")]
        public async Task<CustomerBussines> GetAsync(Guid guid) => await CustomerBussines.GetAsync(guid);
        [HttpPost]
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(CustomerBussines cls) => await cls.SaveAsync();

        [HttpPost]
        public static async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(CustomerBussines cls, bool status) =>
            await cls.ChangeStatusAsync(status);
    }
}
