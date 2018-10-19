namespace IE_Clinics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelMarcacaoAdicionado : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Paciente", newName: "Medico");
            DropIndex("dbo.Medico", new[] { "EspecialidadeID" });
            CreateTable(
                "dbo.Marcacao",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TipoMarcacao = c.String(),
                        Data = c.DateTime(nullable: false),
                        Duracao = c.Int(nullable: false),
                        Observacao = c.String(),
                        PacienteID = c.Int(nullable: false),
                        MedicoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Medico", t => t.MedicoID, cascadeDelete: true)
                .ForeignKey("dbo.Paciente", t => t.PacienteID, cascadeDelete: true)
                .Index(t => t.PacienteID)
                .Index(t => t.MedicoID);
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        UltimoNome = c.String(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Sexo = c.Int(nullable: false),
                        Pais = c.String(nullable: false),
                        Provincia = c.String(nullable: false),
                        Endereco = c.String(nullable: false),
                        Telefone = c.String(nullable: false),
                        TelefoneAlternativo = c.String(),
                        Email = c.String(nullable: false),
                        GrupoSanguineo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Medico", "Departamento", c => c.String());
            AlterColumn("dbo.Medico", "EspecialidadeID", c => c.Int(nullable: true));
            CreateIndex("dbo.Medico", "EspecialidadeID");
            DropColumn("dbo.Medico", "Profissao");
            DropColumn("dbo.Medico", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medico", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Medico", "Profissao", c => c.String());
            DropForeignKey("dbo.Marcacao", "PacienteID", "dbo.Paciente");
            DropForeignKey("dbo.Marcacao", "MedicoID", "dbo.Medico");
            DropIndex("dbo.Marcacao", new[] { "MedicoID" });
            DropIndex("dbo.Marcacao", new[] { "PacienteID" });
            DropIndex("dbo.Medico", new[] { "EspecialidadeID" });
            AlterColumn("dbo.Medico", "EspecialidadeID", c => c.Int());
            DropColumn("dbo.Medico", "Departamento");
            DropTable("dbo.Paciente");
            DropTable("dbo.Marcacao");
            CreateIndex("dbo.Medico", "EspecialidadeID");
            RenameTable(name: "dbo.Medico", newName: "Paciente");
        }
    }
}
