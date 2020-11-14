namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "OrderGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.OrderDetails", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderDetails", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "Total");
            DropColumn("dbo.OrderDetails", "Discount");
            DropColumn("dbo.OrderDetails", "OrderGuid");
        }
    }
}
