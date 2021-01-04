using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines.Building;
using Services;

namespace Server.Controllers
{
    public class BuildingUserController : ApiController
    {
        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(BuildingUserBussines cls) => await cls.SaveAsync();
    }
}
