namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings_Contract", "CodeInArchive", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buildings_Contract", "CodeInArchive");
        }
    }
}
