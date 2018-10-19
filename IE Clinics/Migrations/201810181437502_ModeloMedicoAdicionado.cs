namespace IE_Clinics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloMedicoAdicionado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paciente", "EspecialidadeID", c => c.Int());
            AddColumn("dbo.Paciente", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Paciente", "EspecialidadeID");
            AddForeignKey("dbo.Paciente", "EspecialidadeID", "dbo.Especialidade", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paciente", "EspecialidadeID", "dbo.Especialidade");
            DropIndex("dbo.Paciente", new[] { "EspecialidadeID" });
            DropColumn("dbo.Paciente", "Discriminator");
            DropColumn("dbo.Paciente", "EspecialidadeID");
        }
    }
}
