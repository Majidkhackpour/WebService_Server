using System;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;
using Services;

namespace EntityCache.Persistence.Building
{
    public class ContractFinancePersistenceRepository : GenericRepository<ContractFinanceBussines, ContractFinance>, IContractFinanceRepository
    {
        private ModelContext _db;
        public ContractFinancePersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
        public async Task<ContractFinanceBussines> GetAsync(Guid parentGuid, bool status)
        {
            try
            {
                var acc = _db.ContractFinances.AsNoTracking()
                    .FirstOrDefault(q => q.ConGuid == parentGuid && q.Status == status);

                return Mappings.Default.Map<ContractFinanceBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
