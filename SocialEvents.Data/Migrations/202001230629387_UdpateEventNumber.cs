namespace SocialEvents.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UdpateEventNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventNumber", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.Events", "Reaseon", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Reaseon");
            DropColumn("dbo.Events", "EventNumber");
        }
    }
}
