namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pardakhts", "UserGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.Receptions", "UserGuid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receptions", "UserGuid");
            DropColumn("dbo.Pardakhts", "UserGuid");
        }
    }
}
