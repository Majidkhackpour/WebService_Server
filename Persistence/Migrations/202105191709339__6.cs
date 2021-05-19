namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Department_OrderDetail", "OrderGuid", "dbo.Department_Order");
            DropIndex("dbo.Department_OrderDetail", new[] { "OrderGuid" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Department_OrderDetail", "OrderGuid");
            AddForeignKey("dbo.Department_OrderDetail", "OrderGuid", "dbo.Department_Order", "Guid");
        }
    }
}
