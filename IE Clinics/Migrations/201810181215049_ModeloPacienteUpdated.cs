namespace IE_Clinics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloPacienteUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Paciente", "UltimoNome", c => c.String(nullable: false));
            AlterColumn("dbo.Paciente", "Pais", c => c.String(nullable: false));
            AlterColumn("dbo.Paciente", "Provincia", c => c.String(nullable: false));
            AlterColumn("dbo.Paciente", "Endereco", c => c.String(nullable: false));
            AlterColumn("dbo.Paciente", "Telefone", c => c.String(nullable: false));
            AlterColumn("dbo.Paciente", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Paciente", "Email", c => c.String());
            AlterColumn("dbo.Paciente", "Telefone", c => c.String());
            AlterColumn("dbo.Paciente", "Endereco", c => c.String());
            AlterColumn("dbo.Paciente", "Provincia", c => c.String());
            AlterColumn("dbo.Paciente", "Pais", c => c.String());
            AlterColumn("dbo.Paciente", "UltimoNome", c => c.String());
        }
    }
}
