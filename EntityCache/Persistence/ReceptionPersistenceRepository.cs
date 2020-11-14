using System;
using System.Collections.Generic;
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
    public class ReceptionPersistenceRepository : GenericRepository<ReceptionBussines, Reception>, IReceptionRepository
    {
        private ModelContext db;

        public ReceptionPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<List<ReceptionBussines>> GetAllAsync(Guid receptioGuid)
        {
            try
            {
                var acc = db.Receptions.AsNoTracking()
                    .Where(q => q.Receptor == receptioGuid);

                return Mappings.Default.Map<List<ReceptionBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
