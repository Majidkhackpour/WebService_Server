using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class FloorCoverPersistenceRepository:GenericRepository<FloorCoverBussines,FloorCover>,IFloorCoverRepository
    {
        private ModelContext _db;
        public FloorCoverPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
