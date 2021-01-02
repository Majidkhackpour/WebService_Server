using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.Persistence
{
    public class SyncedDataPersistenceRepository : GenericRepository<SyncedDataBussines, SyncedData>, ISyncedDataRepository
    {
        private ModelContext _db;
        public SyncedDataPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
