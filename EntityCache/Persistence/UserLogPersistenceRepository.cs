using System;
using System.Collections.Generic;
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
    public class UserLogPersistenceRepository : GenericRepository<UserLogBussines, UserLog>, IUserLogRepository
    {
        private ModelContext db;

        public UserLogPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<List<UserLogBussines>> GetAllAsync(Guid userGuid)
        {
            try
            {
                var acc = db.UserLogs.AsNoTracking()
                    .Where(q => q.UserGuid == userGuid);

                return Mappings.Default.Map<List<UserLogBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
