using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class CitiesPersistenceRepository:GenericRepository<CitiesBussiness,Cities>,ICitiesRepository
    {
        private ModelContext _db;
        public CitiesPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
