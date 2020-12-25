using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.Persistence
{
    public class ErrorLogPersistenceRepository : GenericRepository<ErrorLogBussines, ErrorLog>, IErrorLogRepository
    {
        private ModelContext db;
        public ErrorLogPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
