using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class BuildingRequestPersistenceRepository:GenericRepository<BuildingRequestBussines,BuildingRequest>,IBuildingRequestRepository
    {
        private ModelContext _db;
        public BuildingRequestPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
