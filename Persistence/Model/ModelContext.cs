using System.Data.Entity;
using Persistence.Entities;
using Persistence.Migrations;

namespace Persistence.Model
{
    public class ModelContext : DbContext
    {
        public ModelContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ModelContext, Configuration>());
        }

        public ModelContext() : base(Cache.ConnectionString)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ModelContext, Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public virtual DbSet<Customers> Customers { get; set; }
    }
}
