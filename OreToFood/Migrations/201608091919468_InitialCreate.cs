namespace OreToFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestuarantReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(),
                        ViewerName = c.String(),
                        RestuaratId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restuarants", t => t.RestuaratId)
                .Index(t => t.RestuaratId);
            
            CreateTable(
                "dbo.Restuarants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestuarantReviews", "RestuarantId", "dbo.Restuarants");
            DropIndex("dbo.RestuarantReviews", new[] { "RestuarantId" });
            DropTable("dbo.Restuarants");
            DropTable("dbo.RestuarantReviews");
        }
    }
}
