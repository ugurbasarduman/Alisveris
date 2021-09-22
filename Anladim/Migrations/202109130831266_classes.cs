namespace Anladim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Role");
            DropColumn("dbo.Carts", "CreateDate");
        }
    }
}
