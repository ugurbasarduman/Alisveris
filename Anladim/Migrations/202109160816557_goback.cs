namespace Anladim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class goback : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carts", "TotalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
