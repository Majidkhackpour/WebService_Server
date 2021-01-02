using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class BuildingViewPersistenceRepository:GenericRepository<BuildingViewBussines,BuildingView>,IBuildingViewRepository
    {
        private ModelContext _db;
        public BuildingViewPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
