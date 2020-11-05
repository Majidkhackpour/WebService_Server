using EntityCache.Core;
using EntityCache.Persistence;
using Persistence;
using Persistence.Model;

namespace EntityCache.Assistence
{
    public static class UnitOfWork
    {
        private static readonly ModelContext db = new ModelContext(Cache.ConnectionString);

        private static ICustomerRepository _customerRepository;


        public static void Dispose() => db?.Dispose();
        public static void Set_Save() => db.SaveChanges();


        public static ICustomerRepository Customers => _customerRepository ??
                                                (_customerRepository =
                                                    new CustomerPersistenceRepository(db));
    }
}
