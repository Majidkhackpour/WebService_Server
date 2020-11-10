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
        [Route("Products_GetAll")]
        public async Task<IEnumerable<ProductBussines>> GetAllAsync() => await ProductBussines.GetAllAsync();

        [HttpGet]
        [Route("Products_Get/{guid}")]
        public async Task<ProductBussines> GetAsync(Guid guid) => await ProductBussines.GetAsync(guid);

        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(ProductBussines cls) => await cls.SaveAsync();


        [HttpGet]
        [Route("Products_NextCode")]
        public async Task<string> NextCodeAsync() => await ProductBussines.NextCodeAsync();
    }
}
