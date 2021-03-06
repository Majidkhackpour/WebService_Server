﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class CustomerLogPersistenceRepository : GenericRepository<CustomerLogBussines, CustomerLog>, ICustomerLogRepository
    {
        private ModelContext db = new ModelContext();

        public CustomerLogPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<CustomerLogBussines> GetLogByParentAsync(Guid parentGuid)
        {
            try
            {
                var acc = db.CustomerLog.AsNoTracking()
                    .FirstOrDefault(q => q.Parent == parentGuid);

                return Mappings.Default.Map<CustomerLogBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
