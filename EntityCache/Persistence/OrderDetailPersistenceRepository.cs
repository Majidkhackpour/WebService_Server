using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.Persistence
{
    public class OrderDetailPersistenceRepository : GenericRepository<OrderDetailBussines, OrderDetails>, IOrderDetailRepository
    {
        private ModelContext db;

        public OrderDetailPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
