namespace Anladim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addressrules : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAddresses", "Title", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.UserAddresses", "City", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.UserAddresses", "Address", c => c.String(nullable: false, maxLength: 700));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAddresses", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.UserAddresses", "City", c => c.String(nullable: false));
            AlterColumn("dbo.UserAddresses", "Title", c => c.String(nullable: false));
        }
    }
}
