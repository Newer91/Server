namespace SerwisISS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInSlRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SlRoles", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SlRoles", "Active");
        }
    }
}
