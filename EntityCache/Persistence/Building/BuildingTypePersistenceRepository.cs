using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class BuildingTypePersistenceRepository:GenericRepository<BuildingTypeBussines,BuildingType>,IBuildingTypeRepository
    {
        private ModelContext _db;
        public BuildingTypePersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
