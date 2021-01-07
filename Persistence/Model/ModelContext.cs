using System.Data.Entity;
using Persistence.Entities;
using Persistence.Entities.Building;
using Persistence.Migrations;

namespace Persistence.Model
{
    public class ModelContext : DbContext
    {
        public ModelContext()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ModelContext, Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<CustomerLog> CustomerLog { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Reception> Receptions { get; set; }
        public virtual DbSet<SafeBox> SafeBoxe { get; set; }
        public virtual DbSet<SmsLog> SmsLog { get; set; }
        public virtual DbSet<SmsPanels> SmsPanels { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserLog> UserLogs { get; set; }
        public virtual DbSet<Pardakht> Pardakht { get; set; }
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<BuildingUsers> BuildingUsers { get; set; }
        public virtual DbSet<PeopleGroup> PeopleGroups { get; set; }
        public virtual DbSet<Peoples> Peoples { get; set; }
        public virtual DbSet<Hazine> Hazine { get; set; }
        public virtual DbSet<BuildingAccountType> BuildingAccountTypes { get; set; }
        public virtual DbSet<BuildingCondition> BuildingConditions { get; set; }
        public virtual DbSet<BuildingType> BuildingTypes { get; set; }
        public virtual DbSet<BuildingView> BuildingViews { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<FloorCover> FloorCovers { get; set; }
        public virtual DbSet<KitchenService> KitchenServices { get; set; }
        public virtual DbSet<RentalAuthority> RentalAuthorities { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<BuildingGallery> BuildingGalleries { get; set; }
        public virtual DbSet<BuildingRelatedOption> BuildingRelatedOptions { get; set; }
        public virtual DbSet<BuildingRequest> BuildingRequests { get; set; }
        public virtual DbSet<BuildingRequestRegion> BuildingRequestRegions { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractFinance> ContractFinances { get; set; }
        public virtual DbSet<BuildingReception> BuildingReceptions { get; set; }
        public virtual DbSet<BuildingPardakht> BuildingPardakhts { get; set; }
        public virtual DbSet<BuildingGardeshHesab> BuildingGardeshHesabs { get; set; }
        public virtual DbSet<SyncedData> SyncedData { get; set; }
        public virtual DbSet<Androids> Androids { get; set; }
        public virtual DbSet<BuildingOptions> BuildingOptions { get; set; }
        public virtual DbSet<BuildingPhoneBook> BuildingPhoneBooks { get; set; }
    }
}
