using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;
using Servicess.Interfaces.Building;

namespace EntityCache.Persistence.Building
{
    public class BuildingConditionPersistenceRepository:GenericRepository<BuildingConditionBussines,BuildingCondition>,IBuildingConditionRepository
    {
        private ModelContext _db;
        public BuildingConditionPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
