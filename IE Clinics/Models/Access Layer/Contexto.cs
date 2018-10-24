using IE_Clinics.Models.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace IE_Clinics.Models.Access_Layer
{
    public class Contexto : DbContext
    {
        //IEClinics = Connection string
        public Contexto() : base("IEClinics")
        {
        }

        //Definindo as tabelas que farão parte da base de dados
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Marcacao> Marcacoes { get; set; }
        public DbSet<Triagem> Triagens { get; set; }
        public DbSet<AnaliseMedica> AnaliseMedicas { get; set; }
        public DbSet<Prescricao> Prescricoes { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>().HasKey(p => p.ID);

            modelBuilder.Entity<Medico>().HasKey(p => p.ID);
            modelBuilder.Entity<Medico>().HasRequired(p => p.Especialidade).WithMany(p => p.Medicos).HasForeignKey(p => p.EspecialidadeID);

            modelBuilder.Entity<Marcacao>().HasKey(p => p.ID);
            modelBuilder.Entity<Marcacao>().HasRequired(p => p.Paciente).WithMany(p => p.Marcacoes).HasForeignKey(p => p.PacienteID);
            modelBuilder.Entity<Marcacao>().HasRequired(p => p.Medico).WithMany(p => p.Marcacoes).HasForeignKey(p => p.MedicoID);

            //Relacionamentos com as propriedades respectivas a análise médica
            modelBuilder.Entity<Marcacao>().HasOptional(p => p.Triagem).WithRequired(p => p.Marcacao);
            modelBuilder.Entity<Marcacao>().HasOptional(p => p.Prescricao).WithRequired(p => p.Marcacao);
            modelBuilder.Entity<Marcacao>().HasOptional(p => p.AnaliseMedica).WithRequired(p => p.Marcacao);

            modelBuilder.Entity<Triagem>().HasKey(p => p.ID);
            modelBuilder.Entity<Triagem>().HasRequired(p => p.Marcacao).WithOptional(p => p.Triagem);

            //Impede com que o nome das tabelas esteja no plural
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}