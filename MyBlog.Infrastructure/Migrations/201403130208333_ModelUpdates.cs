namespace MyBlog.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Post", "BlogID", "dbo.Blog");
            DropForeignKey("dbo.Comment", "AuthorID", "dbo.Author");
            DropForeignKey("dbo.Post", "AuthorID", "dbo.Author");
            DropIndex("dbo.Post", new[] { "BlogID" });
            DropIndex("dbo.Comment", new[] { "AuthorID" });
            DropIndex("dbo.Post", new[] { "AuthorID" });
            CreateIndex("dbo.Post", "BlogID");
            CreateIndex("dbo.Comment", "AuthorID");
            CreateIndex("dbo.Post", "AuthorID");
            AddForeignKey("dbo.Post", "BlogID", "dbo.Blog", "ID");
            AddForeignKey("dbo.Comment", "AuthorID", "dbo.Author", "ID");
            AddForeignKey("dbo.Post", "AuthorID", "dbo.Author", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "AuthorID", "dbo.Author");
            DropForeignKey("dbo.Comment", "AuthorID", "dbo.Author");
            DropForeignKey("dbo.Post", "BlogID", "dbo.Blog");
            DropIndex("dbo.Post", new[] { "AuthorID" });
            DropIndex("dbo.Comment", new[] { "AuthorID" });
            DropIndex("dbo.Post", new[] { "BlogID" });
            CreateIndex("dbo.Post", "AuthorID");
            CreateIndex("dbo.Comment", "AuthorID");
            CreateIndex("dbo.Post", "BlogID");
            AddForeignKey("dbo.Post", "AuthorID", "dbo.Author", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Comment", "AuthorID", "dbo.Author", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Post", "BlogID", "dbo.Blog", "ID", cascadeDelete: true);
        }
    }
}
