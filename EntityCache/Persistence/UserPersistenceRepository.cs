using System;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.Persistence
{
    public class UserPersistenceRepository : GenericRepository<UserBussines, Users>, IUserRepository
    {
        private ModelContext db;

        public UserPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<UserBussines> GetAsync(string userName)
        {
            try
            {
                var acc = db.Users.AsNoTracking().FirstOrDefault(q => q.UserName == userName);
                return Mappings.Default.Map<UserBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }

        public async Task<bool> CheckUserNameAsync(Guid guid, string userName)
        {
            try
            {
                var acc = db.Users.AsNoTracking()
                    .Where(q => q.UserName == userName && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }
    }
}
