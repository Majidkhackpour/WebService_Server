namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "HardSerial", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "HardSerial");
        }
    }
}
