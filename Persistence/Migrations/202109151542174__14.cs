namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings_Building", "Hiting", c => c.String(maxLength: 250));
            AddColumn("dbo.Buildings_Building", "Colling", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buildings_Building", "Colling");
            DropColumn("dbo.Buildings_Building", "Hiting");
        }
    }
}
