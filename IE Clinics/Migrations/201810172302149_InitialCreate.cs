namespace IE_Clinics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        UltimoNome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Sexo = c.Int(nullable: false),
                        Profissao = c.String(),
                        Pais = c.String(),
                        Provincia = c.String(),
                        Endereco = c.String(),
                        Telefone = c.String(),
                        TelefoneAlternativo = c.String(),
                        Email = c.String(),
                        GrupoSanguineo = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Paciente");
        }
    }
}
