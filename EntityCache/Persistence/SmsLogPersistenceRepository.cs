﻿using System;
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
    public class SmsLogPersistenceRepository : GenericRepository<SmsLogBussines, SmsLog>, ISmsLogRepository
    {
        private ModelContext db;

        public SmsLogPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<SmsLogBussines> GetAsync(long messageId)
        {
            try
            {
                var acc = db.SmsLog.AsNoTracking().FirstOrDefault(q => q.MessageId == messageId);
                return Mappings.Default.Map<SmsLogBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
