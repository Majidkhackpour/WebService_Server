using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class BuildingRelatedOptionPersistenceRepository:GenericRepository<BuildingRelatedOptionsBussines,BuildingRelatedOption>,IBuildingRelatedOptionsRepository
    {
        private ModelContext _db;
        public BuildingRelatedOptionPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
