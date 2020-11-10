using System;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.Persistence
{
    public class SmsPanelPersistenceRepository : GenericRepository<SmsPanelsBussines, SmsPanels>, ISmsPanelRepository
    {
        private ModelContext db;

        public SmsPanelPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<SmsPanelsBussines> GetCurrentAsync()
        {
            try
            {
                var acc = db.SmsPanels.AsNoTracking().FirstOrDefault(q => q.IsCurrent);
                return Mappings.Default.Map<SmsPanelsBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
