namespace IE_Clinics.Migrations
{
    using IE_Clinics.Models.Dominio;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.Access_Layer.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "IE_Clinics.Models.Access_Layer.Contexto";
        }
        CultureInfo cultureInfo = new CultureInfo("pt-AO");
        protected override void Seed(Models.Access_Layer.Contexto contexto)
        {
            //List<Especialidade> especialidades = new List<Especialidade>()
            //{
            //    new Especialidade() {Nome = "Cardiologia", Descricao = "Aborda as doen�as relacionadas com o cora��o e sistema vascular"},
            //    new Especialidade() {Nome = "Dermatologia", Descricao = "� o estudo da pele anexos (pelos, gl�ndulas), tratamento e preven��o das as doen�as"},
            //    new Especialidade() {Nome = "Gastroenterologia", Descricao = "� o estudo, diagn�stico, tratamento e preven��o de doen�as relacionadas ao aparelho digestivo, desde erros inatos do metabolismo, doen�a do trato gastrointestinal, doen�as do f�gado e c�nceres"}
            //};
            //foreach (var especialidade in especialidades)
            //{
            //    contexto.Especialidades.AddOrUpdate(especialidade);
            //}
            //contexto.SaveChanges();

            //Paciente paciente = new Paciente()
            //{
            //    Nome = "Id�lio",
            //    UltimoNome = "Casimiro",
            //    DataNascimento = DateTime.Parse("23/07/1996", cultureInfo),
            //    Sexo = Sexo.M,
            //    Pais = "Angola",
            //    Provincia = "Luanda",
            //    Endereco = "Rua 12 de Julho",
            //    Email = "idiliocasimiro@outlook.com",
            //    GrupoSanguineo = "A+",
            //    Telefone = "944446278",
            //    TelefoneAlternativo = "918014107"
            //};
            //contexto.Pacientes.AddOrUpdate(paciente);

            //Medico medico = new Medico()
            //{
            //    Nome = "Edson",
            //    UltimoNome = "Chinendele",
            //    DataNascimento = DateTime.Parse("01/05/1994", cultureInfo),
            //    Sexo = Sexo.M,
            //    Pais = "Angola",
            //    Provincia = "Luanda",
            //    Endereco = "Zango",
            //    Email = "edsonchinendele@ichostweb.com",
            //    GrupoSanguineo = "B+",
            //    Telefone = "926285616",
            //    TelefoneAlternativo = "",
            //    Departamento = "Ginecologia",
            //    EspecialidadeID = contexto.Especialidades.First().ID
            //};

            //contexto.Medicos.AddOrUpdate(medico);
            //contexto.SaveChanges();
        }
    }
}
