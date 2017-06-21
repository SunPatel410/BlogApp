namespace BA.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingblogtable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Blogs", name: "Category_Id", newName: "CategoryId");
            RenameIndex(table: "dbo.Blogs", name: "IX_Category_Id", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Blogs", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Blogs", name: "CategoryId", newName: "Category_Id");
        }
    }
}
