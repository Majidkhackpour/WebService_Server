﻿namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings_PhoneBook", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buildings_PhoneBook", "Title");
        }
    }
}
