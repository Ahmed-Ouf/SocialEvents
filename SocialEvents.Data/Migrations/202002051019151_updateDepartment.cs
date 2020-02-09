namespace SocialEvents.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDepartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "DepartmentNameAr", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.Departments", "DepartmentName", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.Departments", "DepartmentID", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.Departments", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.Departments", "DepartmentID");
            DropColumn("dbo.Departments", "DepartmentName");
            DropColumn("dbo.Departments", "DepartmentNameAr");
        }
    }
}
