namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ElectronicCigarettes",
                c => new
                    {
                        ElectronicCigarettesId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Produser = c.String(),
                        Weight = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        BattaryPower = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ElectronicCigarettesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ElectronicCigarettes");
        }
    }
}
