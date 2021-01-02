using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class BuildingAccountTypePersistenceRepository:GenericRepository<BuildingAccountTypeBussines,BuildingAccountType>,IBuildingAccountTypeRepository
    {
        private ModelContext _db;
        public BuildingAccountTypePersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
