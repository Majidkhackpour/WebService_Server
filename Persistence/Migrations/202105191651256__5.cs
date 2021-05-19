namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Department_OrderDetail", "OrderGuid");
            AddForeignKey("dbo.Department_OrderDetail", "OrderGuid", "dbo.Department_Order", "Guid");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Department_OrderDetail", "OrderGuid", "dbo.Department_Order");
            DropIndex("dbo.Department_OrderDetail", new[] { "OrderGuid" });
        }
    }
}
