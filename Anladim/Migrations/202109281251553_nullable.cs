namespace Anladim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "ActivationCode", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "ActivationCode", c => c.Guid(nullable: false));
        }
    }
}
