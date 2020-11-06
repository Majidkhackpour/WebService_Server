using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.Persistence
{
    public class SmsPanelPersistenceRepository : GenericRepository<SmsPanelsBussines, SmsPanels>, ISmsPanelRepository
    {
        private ModelContext db;

        public SmsPanelPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
