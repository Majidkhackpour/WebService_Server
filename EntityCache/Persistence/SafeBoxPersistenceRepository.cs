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
    public class SafeBoxPersistenceRepository : GenericRepository<SafeBoxBussines, SafeBox>, ISafeBoxRepository
    {
        private ModelContext db;

        public SafeBoxPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<SafeBoxBussines> GetAsync(string name)
        {
            try
            {
                var acc = db.SafeBoxe.AsNoTracking()
                    .FirstOrDefault(q => q.Name == name);

                return Mappings.Default.Map<SafeBoxBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
