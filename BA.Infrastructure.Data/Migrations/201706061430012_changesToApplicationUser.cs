namespace BA.Infrastructure.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class changesToApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Likes", "User_Id", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Likes", new[] { "User_Id" });
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AlterColumn("dbo.Blogs", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Comments", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Likes", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Blogs", "User_Id");
            CreateIndex("dbo.Comments", "User_Id");
            CreateIndex("dbo.Likes", "User_Id");
            AddForeignKey("dbo.Blogs", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
         
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            DropForeignKey("dbo.Blogs", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Likes", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Blogs", new[] { "User_Id" });
            AlterColumn("dbo.Likes", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Blogs", "User_Id", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Name");
            CreateIndex("dbo.Likes", "User_Id");
            CreateIndex("dbo.Comments", "User_Id");
            CreateIndex("dbo.Blogs", "User_Id");
        }
    }
}
