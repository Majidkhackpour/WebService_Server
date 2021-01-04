using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines.Building;
using Services;

namespace Server.Controllers
{
    public class HazineController : ApiController
    {
        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(HazineBussines cls) => await cls.SaveAsync();
    }
}
