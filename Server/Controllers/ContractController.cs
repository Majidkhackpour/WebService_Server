using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines.Building;
using Services;

namespace Server.Controllers
{
    public class ContractController : ApiController
    {
        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(ContractBussines cls) => await cls.SaveAsync();
    }
}
