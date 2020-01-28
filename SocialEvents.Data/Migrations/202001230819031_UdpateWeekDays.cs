namespace SocialEvents.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UdpateWeekDays : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "WeekDays", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "WeekDays");
        }
    }
}
