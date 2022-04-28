namespace IceCream.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Recipe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AuthorId = c.String(maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        Materral = c.String(),
                        DetailStep = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "AuthorId" });
            DropTable("dbo.Recipes");
        }
    }
}
