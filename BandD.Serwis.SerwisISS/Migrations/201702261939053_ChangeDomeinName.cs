namespace SerwisISS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDomeinName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SlCarrierStats",
                c => new
                    {
                        CarrierStatusId = c.Guid(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.CarrierStatusId);
            
            CreateTable(
                "dbo.SlOrderStats",
                c => new
                    {
                        OrderStatusId = c.Guid(nullable: false),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.OrderStatusId);
            
            CreateTable(
                "dbo.SlRoles",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        Active = c.Boolean(nullable: false),
                        SlRole_RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.SlRoles", t => t.SlRole_RoleId)
                .Index(t => t.SlRole_RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "SlRole_RoleId", "dbo.SlRoles");
            DropIndex("dbo.Users", new[] { "SlRole_RoleId" });
            DropTable("dbo.Users");
            DropTable("dbo.SlRoles");
            DropTable("dbo.SlOrderStats");
            DropTable("dbo.SlCarrierStats");
        }
    }
}
