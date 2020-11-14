namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pardakhts", "NaqdSafeBoxGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.Pardakhts", "BankSafeBoxGuid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pardakhts", "BankSafeBoxGuid");
            DropColumn("dbo.Pardakhts", "NaqdSafeBoxGuid");
        }
    }
}
