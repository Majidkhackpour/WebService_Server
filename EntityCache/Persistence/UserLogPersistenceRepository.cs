using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.Persistence
{
    public class UserLogPersistenceRepository : GenericRepository<UserLogBussines, UserLog>, IUserLogRepository
    {
        private ModelContext db;

        public UserLogPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
