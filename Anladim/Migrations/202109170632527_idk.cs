namespace Anladim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idk : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Users", "Surname", c => c.String(nullable: false, maxLength: 70));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Surname", c => c.String(maxLength: 70));
            AlterColumn("dbo.Users", "Name", c => c.String(maxLength: 70));
        }
    }
}
