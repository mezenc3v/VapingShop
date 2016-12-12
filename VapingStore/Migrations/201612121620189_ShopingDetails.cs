namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShopingDetails : DbMigration
    {
        public override void Up()
        {        
            CreateTable(
                "dbo.ShopingDetails",
                c => new
                    {
                        ShopingDetailsId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Line1 = c.String(nullable: false),
                        Line2 = c.String(),
                        Line3 = c.String(),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ShopingDetailsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShopingDetails");
            DropTable("dbo.ElectronicCigarettes");
        }
    }
}
