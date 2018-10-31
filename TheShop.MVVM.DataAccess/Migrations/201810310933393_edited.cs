namespace TheShop.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edited : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Product", name: "Category_Id", newName: "FavoriteCategoryId");
            RenameIndex(table: "dbo.Product", name: "IX_Category_Id", newName: "IX_FavoriteCategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Product", name: "IX_FavoriteCategoryId", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Product", name: "FavoriteCategoryId", newName: "Category_Id");
        }
    }
}
