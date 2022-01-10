namespace School.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClassRoom", "Schools_SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Teacher", "Schools_SchoolId", "dbo.Schools");
            DropIndex("dbo.ClassRoom", new[] { "Schools_SchoolId" });
            DropIndex("dbo.Teacher", new[] { "Schools_SchoolId" });
            RenameColumn(table: "dbo.ClassRoom", name: "Schools_SchoolId", newName: "SchoolId");
            RenameColumn(table: "dbo.Teacher", name: "Schools_SchoolId", newName: "SchoolId");
            AlterColumn("dbo.ClassRoom", "SchoolId", c => c.Int(nullable: false));
            AlterColumn("dbo.Teacher", "SchoolId", c => c.Int(nullable: false));
            CreateIndex("dbo.ClassRoom", "SchoolId");
            CreateIndex("dbo.Teacher", "SchoolId");
            AddForeignKey("dbo.ClassRoom", "SchoolId", "dbo.Schools", "SchoolId", cascadeDelete: true);
            AddForeignKey("dbo.Teacher", "SchoolId", "dbo.Schools", "SchoolId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teacher", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.ClassRoom", "SchoolId", "dbo.Schools");
            DropIndex("dbo.Teacher", new[] { "SchoolId" });
            DropIndex("dbo.ClassRoom", new[] { "SchoolId" });
            AlterColumn("dbo.Teacher", "SchoolId", c => c.Int());
            AlterColumn("dbo.ClassRoom", "SchoolId", c => c.Int());
            RenameColumn(table: "dbo.Teacher", name: "SchoolId", newName: "Schools_SchoolId");
            RenameColumn(table: "dbo.ClassRoom", name: "SchoolId", newName: "Schools_SchoolId");
            CreateIndex("dbo.Teacher", "Schools_SchoolId");
            CreateIndex("dbo.ClassRoom", "Schools_SchoolId");
            AddForeignKey("dbo.Teacher", "Schools_SchoolId", "dbo.Schools", "SchoolId");
            AddForeignKey("dbo.ClassRoom", "Schools_SchoolId", "dbo.Schools", "SchoolId");
        }
    }
}
