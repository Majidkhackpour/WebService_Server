using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class BuildingPardakhtPersistenceRepository:GenericRepository<BuildingPardakhtBussines,BuildingPardakht>,IBuildingPardakhtRepository
    {
        private ModelContext _db;
        public BuildingPardakhtPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
