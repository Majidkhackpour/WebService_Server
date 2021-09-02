namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Department_Product", "Unit", c => c.String(nullable: false));
            AlterColumn("dbo.Department_Product", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Department_Product", "Code", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Department_Product", "Code", c => c.String(maxLength: 50));
            AlterColumn("dbo.Department_Product", "Name", c => c.String(maxLength: 200));
            DropColumn("dbo.Department_Product", "Unit");
        }
    }
}
