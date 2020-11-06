using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.Persistence
{
    public class SafeBoxPersistenceRepository : GenericRepository<SafeBoxBussines, SafeBox>, ISafeBoxRepository
    {
        private ModelContext db;

        public SafeBoxPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
