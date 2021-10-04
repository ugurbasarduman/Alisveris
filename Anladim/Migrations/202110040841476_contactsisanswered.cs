namespace Anladim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactsisanswered : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "isAnswered", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "isAnswered");
        }
    }
}
