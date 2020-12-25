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
    public class CustomerPersistenceRepository : GenericRepository<CustomerBussines, Customers>, ICustomerRepository
    {
        private ModelContext db;
        public CustomerPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<CustomerBussines> GetAsync(string name)
        {
            try
            {
                var acc = db.Customers.AsNoTracking()
                    .FirstOrDefault(q => q.Name == name);

                return Mappings.Default.Map<CustomerBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }

        public async Task<CustomerBussines> GetByHardSerialAsync(string hSerial)
        {
            try
            {
                var acc = db.Customers.AsNoTracking()
                    .FirstOrDefault(q => q.HardSerial == hSerial);

                return Mappings.Default.Map<CustomerBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
