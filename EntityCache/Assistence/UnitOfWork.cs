using Persistence;
using Persistence.Model;

namespace EntityCache.Assistence
{
    public static class UnitOfWork
    {
        private static readonly ModelContext db = new ModelContext(Cache.ConnectionString);


        public static void Dispose() => db?.Dispose();
        public static void Set_Save() => db.SaveChanges();

    }
}
