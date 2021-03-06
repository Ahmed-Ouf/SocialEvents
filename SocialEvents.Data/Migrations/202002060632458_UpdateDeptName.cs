﻿namespace SocialEvents.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDeptName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "DepartmentNameEn", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.Departments", "DepartmentName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "DepartmentName", c => c.String(nullable: false, maxLength: 500));
            DropColumn("dbo.Departments", "DepartmentNameEn");
        }
    }
}
