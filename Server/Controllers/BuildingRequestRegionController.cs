using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines.Building;
using Services;

namespace Server.Controllers
{
    public class BuildingRequestRegionController : ApiController
    {
        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(BuildingRelatedRegionsBussines cls) => await cls.SaveAsync();
    }
}
