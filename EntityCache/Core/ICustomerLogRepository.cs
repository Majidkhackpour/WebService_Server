using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface ICustomerLogRepository : IRepository<CustomerLogBussines>
    {
        Task<CustomerLogBussines> GetLogByParentAsync(Guid parentGuid);
    }
}
