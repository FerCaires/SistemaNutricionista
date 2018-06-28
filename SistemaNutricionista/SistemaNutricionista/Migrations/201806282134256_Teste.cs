namespace SistemaNutricionista.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanoAlimentar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        Desjejum = c.String(),
                        Colacao = c.String(),
                        Almoco = c.String(),
                        LancheTarde = c.String(),
                        LancheTardeDois = c.String(),
                        Jantar = c.String(),
                        Ceia = c.String(),
                        CeiaDois = c.String(),
                        DataRegistro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlanoAlimentar");
        }
    }
}
