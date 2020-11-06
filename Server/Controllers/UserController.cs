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
        [Route("User_GetAll")]
        public async Task<IEnumerable<UserBussines>> GetAllAsync() => await UserBussines.GetAllAsync();
        [HttpGet]
        [Route("User_Get/{guid}")]
        public async Task<UserBussines> GetAsync(Guid guid) => await UserBussines.GetAsync(guid);
        [HttpPost]
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(UserBussines cls) => await cls.SaveAsync();

        [HttpPost]
        public static async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(UserBussines cls, bool status) =>
            await cls.ChangeStatusAsync(status);

        [HttpGet]
        [Route("User_CheckUserName/{guid},{userName}")]
        public async Task<bool> CheckUserNameAsync(Guid guid, string userName) => await UserBussines.CheckUserNameAsync(guid, userName);
        [HttpGet]
        [Route("User_Get/{userName}")]
        public async Task<UserBussines> GetAsync(string userName) => await UserBussines.GetAsync(userName);
    }
}
