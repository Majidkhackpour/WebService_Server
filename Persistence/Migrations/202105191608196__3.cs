namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Department_Order", "LearningCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Department_Order", "LearningCount", c => c.Int(nullable: false));
        }
    }
}
