namespace Anladim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Name");
        }
    }
}
