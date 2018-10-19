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
        public IDbSet<Paciente> Pacientes { get; set; }
        public IDbSet<Medico> Medicos { get; set; }
        public IDbSet<Especialidade> Especialidades { get; set; }
        public IDbSet<Marcacao> Marcacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>().HasKey(p => p.ID);

            modelBuilder.Entity<Medico>().HasKey(p => p.ID);
            modelBuilder.Entity<Medico>().HasRequired(p => p.Especialidade).WithMany(p => p.Medicos).HasForeignKey(p => p.EspecialidadeID);

            modelBuilder.Entity<Marcacao>().HasKey(p => p.ID);
            modelBuilder.Entity<Marcacao>().HasRequired(p => p.Paciente).WithMany(p => p.Marcacoes).HasForeignKey(p => p.PacienteID);
            modelBuilder.Entity<Marcacao>().HasRequired(p => p.Medico).WithMany(p => p.Marcacoes).HasForeignKey(p => p.MedicoID);

            //Impede com que o nome das tabelas esteja no plural
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}