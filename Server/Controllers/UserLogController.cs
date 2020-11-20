using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines;

namespace Server.Controllers
{
    public class UserLogController : ApiController
    {
        [HttpGet]
        [Route("UserLog_GetAll/{userGuid}")]
        public async Task<IEnumerable<UserLogBussines>> GetAllAsync(Guid userGuid) =>
            await UserLogBussines.GetAllAsync(userGuid);
    }
}
