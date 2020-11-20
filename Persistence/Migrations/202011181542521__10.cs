namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Version");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Version", c => c.String(maxLength: 50));
        }
    }
}
