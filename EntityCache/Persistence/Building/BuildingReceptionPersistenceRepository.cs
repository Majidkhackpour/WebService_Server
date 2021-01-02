using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class BuildingReceptionPersistenceRepository:GenericRepository<BuildingReceptionBussines,BuildingReception>,IBuildingReceptionRepository
    {
        private ModelContext _db;
        public BuildingReceptionPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
