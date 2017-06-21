namespace BA.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedUserDetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Likes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Blogs", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Blogs", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Likes", new[] { "User_Id" });
            AddColumn("dbo.Blogs", "User", c => c.String(maxLength: 30));
            AddColumn("dbo.Comments", "User", c => c.String(maxLength: 30));
            AddColumn("dbo.Likes", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Blogs", "Hide");
            DropColumn("dbo.Blogs", "User_Id");
            DropColumn("dbo.Comments", "User_Id");
            DropColumn("dbo.Likes", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Likes", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Comments", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Blogs", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Blogs", "Hide", c => c.Boolean(nullable: false));
            DropColumn("dbo.Likes", "UserId");
            DropColumn("dbo.Comments", "User");
            DropColumn("dbo.Blogs", "User");
            CreateIndex("dbo.Likes", "User_Id");
            CreateIndex("dbo.Comments", "User_Id");
            CreateIndex("dbo.Blogs", "User_Id");
            AddForeignKey("dbo.Blogs", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Likes", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
