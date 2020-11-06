using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IUserRepository : IRepository<UserBussines>
    {
        Task<UserBussines> GetAsync(string userName);
        Task<bool> CheckUserNameAsync(Guid guid, string userName);
    }
}
