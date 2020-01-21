namespace SocialEvents.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Announcements", "EventImage_Name", c => c.String(maxLength: 500));
            AddColumn("dbo.Announcements", "EventImage_FileBase64", c => c.String());
            AddColumn("dbo.Categories", "EventImage_Name", c => c.String(maxLength: 500));
            AddColumn("dbo.Categories", "EventImage_FileBase64", c => c.String());
            DropColumn("dbo.Announcements", "EventImage_FullName");
            DropColumn("dbo.Categories", "EventImage_FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "EventImage_FullName", c => c.String(maxLength: 500));
            AddColumn("dbo.Announcements", "EventImage_FullName", c => c.String(maxLength: 500));
            DropColumn("dbo.Categories", "EventImage_FileBase64");
            DropColumn("dbo.Categories", "EventImage_Name");
            DropColumn("dbo.Announcements", "EventImage_FileBase64");
            DropColumn("dbo.Announcements", "EventImage_Name");
        }
    }
}
