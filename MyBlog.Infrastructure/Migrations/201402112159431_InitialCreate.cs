namespace MyBlog.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Content = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PostID = c.Guid(nullable: false),
                        AuthorID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Post", t => t.PostID)
                .ForeignKey("dbo.Author", t => t.AuthorID, cascadeDelete: true)
                .Index(t => t.PostID)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        AuthorID = c.Guid(nullable: false),
                        BlogID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Blog", t => t.BlogID, cascadeDelete: true)
                .ForeignKey("dbo.Author", t => t.AuthorID, cascadeDelete: true)
                .Index(t => t.BlogID)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false),
                        Category = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false),
                        EventType = c.String(nullable: false),
                        EventDetail = c.String(),
                        Description = c.String(),
                        Metric = c.Double(),
                        MetricDescription = c.String(),
                        MetricUnit = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Error",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false),
                        EventType = c.String(nullable: false),
                        EventDetail = c.String(),
                        Description = c.String(),
                        StackTrace = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "AuthorID", "dbo.Author");
            DropForeignKey("dbo.Comment", "AuthorID", "dbo.Author");
            DropForeignKey("dbo.Comment", "PostID", "dbo.Post");
            DropForeignKey("dbo.Post", "BlogID", "dbo.Blog");
            DropIndex("dbo.Post", new[] { "AuthorID" });
            DropIndex("dbo.Comment", new[] { "AuthorID" });
            DropIndex("dbo.Comment", new[] { "PostID" });
            DropIndex("dbo.Post", new[] { "BlogID" });
            DropTable("dbo.Error");
            DropTable("dbo.Log");
            DropTable("dbo.Blog");
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
            DropTable("dbo.Author");
        }
    }
}
