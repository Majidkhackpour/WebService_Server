﻿using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface ISmsLogRepository : IRepository<SmsLogBussines>
    {
        Task<SmsLogBussines> GetAsync(long messageId);
    }
}
