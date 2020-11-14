namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerLogs", "Parent", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerLogs", "Parent");
        }
    }
}
