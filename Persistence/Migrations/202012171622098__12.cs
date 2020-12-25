namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "LkSerial", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "LkSerial");
        }
    }
}
