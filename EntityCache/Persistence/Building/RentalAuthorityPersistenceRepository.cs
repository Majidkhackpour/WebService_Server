using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class RentalAuthorityPersistenceRepository:GenericRepository<RentalAuthorityBussines,RentalAuthority>,IRentalAuthorityRepository
    {
        private ModelContext _db;
        public RentalAuthorityPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
