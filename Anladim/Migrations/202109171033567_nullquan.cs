namespace Anladim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullquan : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "QuantityProd", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "QuantityProd", c => c.Int(nullable: false));
        }
    }
}
