namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Department_OrderDetail", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Department_OrderDetail", "Count");
        }
    }
}
