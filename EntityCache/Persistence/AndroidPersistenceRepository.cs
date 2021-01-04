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
    public class AndroidPersistenceRepository : GenericRepository<AndroidsBussines, Androids>, IAndroidsRepository
    {
        private ModelContext _db;
        public AndroidPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }

        public async Task<AndroidsBussines> GetAsync(string imei)
        {
            try
            {
                var acc = _db.Androids.AsNoTracking()
                    .FirstOrDefault(q => q.IMEI == imei);

                return Mappings.Default.Map<AndroidsBussines>(acc);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
