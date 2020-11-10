using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using EntityCache.Bussines;
using Services;

namespace Server.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("Users_GetAll")]
        public async Task<IEnumerable<UserBussines>> GetAllAsync() => await UserBussines.GetAllAsync();
        [HttpGet]
        [Route("Users_Get/{guid}")]
        public async Task<UserBussines> GetAsync(Guid guid) => await UserBussines.GetAsync(guid);

        [HttpPost]
        public async Task<ReturnedSaveFuncInfo> SaveAsync(UserBussines cls) => await cls.SaveAsync();

        [HttpGet]
        [Route("Users_CheckUserName/{guid},{userName}")]
        public async Task<bool> CheckUserNameAsync(Guid guid, string userName) => await UserBussines.CheckUserNameAsync(guid, userName);
        [HttpGet]
        [Route("User_Get/{userName}")]
        public async Task<UserBussines> GetAsync(string userName) => await UserBussines.GetAsync(userName);
    }
}
