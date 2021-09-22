namespace Anladim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressUserIdNull : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserAddresses", new[] { "UserId" });
            AlterColumn("dbo.UserAddresses", "UserId", c => c.Int());
            CreateIndex("dbo.UserAddresses", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserAddresses", new[] { "UserId" });
            AlterColumn("dbo.UserAddresses", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserAddresses", "UserId");
        }
    }
}
