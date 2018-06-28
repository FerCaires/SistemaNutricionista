namespace SistemaNutricionista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Idade = c.Int(nullable: false),
                        Email = c.String(),
                        Endereco = c.String(),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Medidas",
                c => new
                    {
                        MedidasId = c.Int(nullable: false),
                        Altura = c.Int(nullable: false),
                        Peso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IMC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cintura = c.Int(nullable: false),
                        Abdomen = c.Int(nullable: false),
                        PorcentagemGordura = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PorcentagemGorduraViceral = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Coxa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedidasId)
                .ForeignKey("dbo.Clientes", t => t.MedidasId)
                .Index(t => t.MedidasId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medidas", "MedidasId", "dbo.Clientes");
            DropIndex("dbo.Medidas", new[] { "MedidasId" });
            DropTable("dbo.Medidas");
            DropTable("dbo.Clientes");
        }
    }
}
