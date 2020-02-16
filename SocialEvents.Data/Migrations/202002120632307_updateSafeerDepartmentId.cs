namespace SocialEvents.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSafeerDepartmentId : DbMigration
    {
        public override void Up()
        {

            RenameColumn("dbo.Departments", "DepartmentID", "SafeerDepartmentId");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Departments", "SafeerDepartmentId", "DepartmentID");

        }
    }
}
