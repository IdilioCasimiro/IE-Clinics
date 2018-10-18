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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Impede com que o nome das tabelas esteja no plural
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}