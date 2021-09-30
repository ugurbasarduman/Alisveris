namespace Anladim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class logindeneme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsEmailVerified", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Users", "ActivationCode", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ActivationCode");
            DropColumn("dbo.Users", "ConfirmPassword");
            DropColumn("dbo.Users", "IsEmailVerified");
        }
    }
}
