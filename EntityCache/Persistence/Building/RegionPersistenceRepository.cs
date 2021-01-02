using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class RegionPersistenceRepository:GenericRepository<RegionBussines,Regions>,IRegionRepository
    {
        private ModelContext _db;
        public RegionPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
