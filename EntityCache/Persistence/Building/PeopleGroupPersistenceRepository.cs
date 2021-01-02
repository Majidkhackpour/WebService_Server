using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class PeopleGroupPersistenceRepository:GenericRepository<PeopleGroupBussines,PeopleGroup>,IPeopleGroupRepository
    {
        private ModelContext _db;
        public PeopleGroupPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
