namespace Anladim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idk2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "QuantityProd", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "QuantityProd");
        }
    }
}
