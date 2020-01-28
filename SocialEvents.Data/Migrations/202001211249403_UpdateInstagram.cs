namespace SocialEvents.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInstagram : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "InstagramUrl", c => c.String(maxLength: 500));
            AlterColumn("dbo.Events", "TargetAge", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Events", "EventUrl", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Events", "FacebookUrl", c => c.String(maxLength: 500));
            AlterColumn("dbo.Events", "twitterUrl", c => c.String(maxLength: 500));
            DropColumn("dbo.Events", "InstagrammUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "InstagrammUrl", c => c.String());
            AlterColumn("dbo.Events", "twitterUrl", c => c.String());
            AlterColumn("dbo.Events", "FacebookUrl", c => c.String());
            AlterColumn("dbo.Events", "EventUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "TargetAge", c => c.String(nullable: false));
            DropColumn("dbo.Events", "InstagramUrl");
        }
    }
}
