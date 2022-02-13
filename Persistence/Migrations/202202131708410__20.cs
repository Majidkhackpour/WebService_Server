namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Buildings_PhoneBook", "ServerStatus");
            DropColumn("dbo.Buildings_PhoneBook", "ServerDeliveryDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buildings_PhoneBook", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Buildings_PhoneBook", "ServerStatus", c => c.Short(nullable: false));
        }
    }
}
