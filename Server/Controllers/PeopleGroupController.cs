using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines.Building;
using Services;

namespace Server.Controllers
{
    public class PeopleGroupController : ApiController
    {
        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(PeopleGroupBussines cls) => await cls.SaveAsync();
    }
}
