using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class HazinePersistenceRepository:GenericRepository<HazineBussines,Hazine>,IHazineRepository
    {
        private ModelContext _db;
        public HazinePersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
