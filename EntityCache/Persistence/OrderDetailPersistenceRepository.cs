using System;
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
    public class OrderDetailPersistenceRepository : GenericRepository<OrderDetailBussines, OrderDetails>, IOrderDetailRepository
    {
        private ModelContext db;

        public OrderDetailPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<List<OrderDetailBussines>> GetAllAsync(Guid orderGuid)
        {
            try
            {
                var acc = db.OrderDetails.AsNoTracking()
                    .Where(q => q.OrderGuid == orderGuid);

                return Mappings.Default.Map<List<OrderDetailBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
