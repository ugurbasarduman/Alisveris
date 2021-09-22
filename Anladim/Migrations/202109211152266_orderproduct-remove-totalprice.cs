namespace Anladim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderproductremovetotalprice : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderProducts", "TotalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderProducts", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
