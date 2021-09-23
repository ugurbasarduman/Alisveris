namespace Anladim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class classchanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "QuantityProd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "QuantityProd", c => c.Int());
        }
    }
}
