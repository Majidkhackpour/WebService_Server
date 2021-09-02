namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Department_Scrapper", "DateM", c => c.DateTime(nullable: false));
            AddColumn("dbo.Department_Scrapper", "Type", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Department_Scrapper", "Type");
            DropColumn("dbo.Department_Scrapper", "DateM");
        }
    }
}
