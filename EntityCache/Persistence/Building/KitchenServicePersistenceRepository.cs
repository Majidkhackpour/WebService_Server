using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class KitchenServicePersistenceRepository:GenericRepository<KitchenServiceBussines,KitchenService>,IKitchenServiceRepository
    {
        private ModelContext _db;
        public KitchenServicePersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
