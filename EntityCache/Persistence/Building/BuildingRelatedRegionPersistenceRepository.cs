using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class BuildingRelatedRegionPersistenceRepository:GenericRepository<BuildingRelatedRegionsBussines,BuildingRequestRegion>,IBuildingRelatedRegionsRepository
    {
        private ModelContext _db;
        public BuildingRelatedRegionPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
