namespace SocialEvents.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 500),
                        Published = c.Boolean(nullable: false),
                        EventImage_FullName = c.String(maxLength: 500),
                        CreatedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Color = c.String(nullable: false, maxLength: 20),
                        EventImage_FullName = c.String(maxLength: 500),
                        CreatedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        LocationId = c.Guid(nullable: false),
                        TargetGroupId = c.Guid(nullable: false),
                        DepartmentId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 500),
                        Description = c.String(nullable: false, maxLength: 500),
                        Address = c.String(nullable: false, maxLength: 500),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        TimeFrom = c.Time(nullable: false, precision: 7),
                        TimeTo = c.Time(nullable: false, precision: 7),
                        Fees = c.Double(nullable: false),
                        TargetAge = c.String(nullable: false),
                        EventUrl = c.String(nullable: false),
                        FacebookUrl = c.String(),
                        twitterUrl = c.String(),
                        InstagrammUrl = c.String(),
                        State = c.Int(nullable: false),
                        Notifiable = c.Boolean(nullable: false),
                        Published = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.TargetGroups", t => t.TargetGroupId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.LocationId)
                .Index(t => t.TargetGroupId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 500),
                        CreatedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 500),
                        Longitude = c.String(nullable: false, maxLength: 100),
                        Latitude = c.String(nullable: false, maxLength: 100),
                        CreatedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TargetGroups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 500),
                        CreatedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 500),
                        CreatedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "TargetGroupId", "dbo.TargetGroups");
            DropForeignKey("dbo.Events", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Events", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Events", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Events", new[] { "DepartmentId" });
            DropIndex("dbo.Events", new[] { "TargetGroupId" });
            DropIndex("dbo.Events", new[] { "LocationId" });
            DropIndex("dbo.Events", new[] { "CategoryId" });
            DropTable("dbo.Notifications");
            DropTable("dbo.TargetGroups");
            DropTable("dbo.Locations");
            DropTable("dbo.Departments");
            DropTable("dbo.Events");
            DropTable("dbo.Categories");
            DropTable("dbo.Announcements");
        }
    }
}
