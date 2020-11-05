using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.Persistence
{
    public class CustomerPersistenceRepository : GenericRepository<CustomerBussines, Customers>, ICustomerRepository
    {
        private ModelContext db;
        public CustomerPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
