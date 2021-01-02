using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class PeoplePersistenceRepository:GenericRepository<PeopleBussines,Peoples>,IPeoplesRepository
    {
        private ModelContext _db;
        public PeoplePersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
