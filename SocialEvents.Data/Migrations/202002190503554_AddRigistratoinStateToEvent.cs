namespace SocialEvents.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRigistratoinStateToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "RegistrationState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "RegistrationState");
        }
    }
}
