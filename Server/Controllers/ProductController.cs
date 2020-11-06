using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines;
using Services;

namespace Server.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("Product_GetAll")]
        public static async Task<IEnumerable<ProductBussines>> GetAllAsync() => await ProductBussines.GetAllAsync();

        [HttpGet]
        [Route("Pruduct_Get/{guid}")]
        public static async Task<ProductBussines> GetAsync(Guid guid) => await ProductBussines.GetAsync(guid);

        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(ProductBussines cls) => await cls.SaveAsync();

        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> ChangStatusAsync(ProductBussines cls, bool status) =>
            await cls.ChangeStatusAsync(status);

        [HttpGet]
        [Route("Product_NextCode")]
        public static async Task<string> NextCodeAsync() => await ProductBussines.NextCodeAsync();
    }
}
