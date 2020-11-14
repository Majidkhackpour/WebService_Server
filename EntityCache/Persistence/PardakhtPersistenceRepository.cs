﻿using System;
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
    public class PardakhtPersistenceRepository : GenericRepository<PardakhtBussines, Pardakht>, IPardakhtRepository
    {
        private ModelContext db;
        public PardakhtPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<List<PardakhtBussines>> GetAllAsync(Guid receptioGuid)
        {
            try
            {
                var acc = db.Pardakht.AsNoTracking()
                    .Where(q => q.Payer == receptioGuid);

                return Mappings.Default.Map<List<PardakhtBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
