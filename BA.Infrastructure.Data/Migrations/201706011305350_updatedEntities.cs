namespace BA.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Comment_Id", "dbo.Comments");
            DropIndex("dbo.Comments", new[] { "Comment_Id" });
            DropColumn("dbo.Comments", "Comment_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Comment_Id", c => c.Int());
            CreateIndex("dbo.Comments", "Comment_Id");
            AddForeignKey("dbo.Comments", "Comment_Id", "dbo.Comments", "Id");
        }
    }
}
