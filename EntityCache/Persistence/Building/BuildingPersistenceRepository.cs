using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class BuildingPersistenceRepository:GenericRepository<BuildingBusines,global::Persistence.Entities.Building.Building>,IBuildingRepository
    {
        private ModelContext _db;
        public BuildingPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
