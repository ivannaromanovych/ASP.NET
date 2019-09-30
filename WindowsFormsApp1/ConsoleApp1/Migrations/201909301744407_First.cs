namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ZipCode = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCountry", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.tblCountry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblCity", "CountryId", "dbo.tblCountry");
            DropIndex("dbo.tblCity", new[] { "CountryId" });
            DropTable("dbo.tblCountry");
            DropTable("dbo.tblCity");
        }
    }
}
