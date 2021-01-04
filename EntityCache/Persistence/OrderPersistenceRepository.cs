using System;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.Persistence
{
    public class OrderPersistenceRepository : GenericRepository<OrderBussines, Order>, IOrderRepository
    {
        private ModelContext db;

        public OrderPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
        public async Task<string> NextCodeAsync()
        {
            try
            {
                throw new NotImplementedException();
                var all = await GetAllAsync();
                if (all.Count <= 0) return "1001";
                var code = all.ToList()?.Max(q => long.Parse(q.ContractCode)) ?? 0;
                code += 1;
                var new_code = code.ToString();
                if (code < 10)
                {
                    new_code = "000" + code;
                    return new_code;
                }
                if (code >= 10 && code < 100)
                {
                    new_code = "00" + code;
                    return new_code;
                }
                if (code >= 100 && code < 1000)
                {
                    new_code = "0" + code;
                    return new_code;
                }

                if (code >= 1000 && code < 10000)
                {
                    new_code = code.ToString();
                    return new_code;
                }

                return new_code;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return "001001";
            }
        }
    }
}
