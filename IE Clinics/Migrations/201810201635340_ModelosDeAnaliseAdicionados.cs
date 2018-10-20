namespace IE_Clinics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelosDeAnaliseAdicionados : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnaliseMedica",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        IndicacaoClinica = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Marcacao", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Exame",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        Valor = c.Int(nullable: false),
                        AnaliseMedica_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AnaliseMedica", t => t.AnaliseMedica_ID)
                .Index(t => t.AnaliseMedica_ID);
            
            CreateTable(
                "dbo.Prescricao",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Posologia = c.String(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Marcacao", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Medicamento",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        Prescricao_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Prescricao", t => t.Prescricao_ID)
                .Index(t => t.Prescricao_ID);
            
            CreateTable(
                "dbo.Triagem",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Peso = c.Int(nullable: false),
                        FrenquenciaCardiaca = c.Int(nullable: false),
                        PressaoArterial = c.Int(nullable: false),
                        Observacoes = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Marcacao", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Triagem", "ID", "dbo.Marcacao");
            DropForeignKey("dbo.Prescricao", "ID", "dbo.Marcacao");
            DropForeignKey("dbo.Medicamento", "Prescricao_ID", "dbo.Prescricao");
            DropForeignKey("dbo.AnaliseMedica", "ID", "dbo.Marcacao");
            DropForeignKey("dbo.Exame", "AnaliseMedica_ID", "dbo.AnaliseMedica");
            DropIndex("dbo.Triagem", new[] { "ID" });
            DropIndex("dbo.Medicamento", new[] { "Prescricao_ID" });
            DropIndex("dbo.Prescricao", new[] { "ID" });
            DropIndex("dbo.Exame", new[] { "AnaliseMedica_ID" });
            DropIndex("dbo.AnaliseMedica", new[] { "ID" });
            DropTable("dbo.Triagem");
            DropTable("dbo.Medicamento");
            DropTable("dbo.Prescricao");
            DropTable("dbo.Exame");
            DropTable("dbo.AnaliseMedica");
        }
    }
}
