using EntityCache.Bussines.Building;
using EntityCache.Core.Building;
using Persistence.Entities.Building;
using Persistence.Model;

namespace EntityCache.Persistence.Building
{
    public class ContractFinancePersistenceRepository:GenericRepository<ContractFinanceBussines,ContractFinance>,IContractFinanceRepository
    {
        private ModelContext _db;
        public ContractFinancePersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
