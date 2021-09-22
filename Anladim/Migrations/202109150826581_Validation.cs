namespace Anladim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Brand", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(maxLength: 70));
            AlterColumn("dbo.Users", "Surname", c => c.String(maxLength: 70));
            AlterColumn("dbo.Users", "Mail", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Phone", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.UserAddresses", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.UserAddresses", "City", c => c.String(nullable: false));
            AlterColumn("dbo.UserAddresses", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAddresses", "Address", c => c.String());
            AlterColumn("dbo.UserAddresses", "City", c => c.String());
            AlterColumn("dbo.UserAddresses", "Title", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Phone", c => c.String());
            AlterColumn("dbo.Users", "Mail", c => c.String());
            AlterColumn("dbo.Users", "Surname", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
            AlterColumn("dbo.Products", "Model", c => c.String());
            AlterColumn("dbo.Products", "Brand", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
