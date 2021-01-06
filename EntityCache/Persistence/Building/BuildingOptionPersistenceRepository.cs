using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class BuildingOptionPersistenceRepository : GenericRepository<BuildingOptionBussines, BuildingOptions>, IBuildingOptionRepository
    {
        private ModelContext _db;
        public BuildingOptionPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
