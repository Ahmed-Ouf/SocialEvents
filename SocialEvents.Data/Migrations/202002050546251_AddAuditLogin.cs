namespace SocialEvents.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuditLogin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginAudits",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        LoginDate = c.DateTime(nullable: false),
                        Data = c.String(),
                        RequestMethod = c.String(maxLength: 100),
                        BrowserInfo = c.String(),
                        AuthorizedStatus = c.String(maxLength: 1000),
                        Notes = c.String(),
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
            DropTable("dbo.LoginAudits");
        }
    }
}
