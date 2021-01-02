using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class StatePersistenceRepository:GenericRepository<StateBussines,States>,IStateRepository
    {
        private ModelContext _db;
        public StatePersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
