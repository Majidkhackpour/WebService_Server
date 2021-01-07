using System;
using System.Threading.Tasks;
using EntityCache.Bussines.Building;

namespace EntityCache.Core.Building
{
    public interface IContractFinanceRepository:IRepository<ContractFinanceBussines>
    {
        Task<ContractFinanceBussines> GetAsync(Guid parentGuid, bool status);
    }
}
