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
            //    new Especialidade() {Nome = "Cardiologia", Descricao = "Aborda as doenças relacionadas com o coração e sistema vascular"},
            //    new Especialidade() {Nome = "Dermatologia", Descricao = "É o estudo da pele anexos (pelos, glândulas), tratamento e prevenção das as doenças"},
            //    new Especialidade() {Nome = "Gastroenterologia", Descricao = "É o estudo, diagnóstico, tratamento e prevenção de doenças relacionadas ao aparelho digestivo, desde erros inatos do metabolismo, doença do trato gastrointestinal, doenças do fígado e cânceres"}
            //};
            //foreach (var especialidade in especialidades)
            //{
            //    contexto.Especialidades.AddOrUpdate(especialidade);
            //}
            //contexto.SaveChanges();

            //Paciente paciente = new Paciente()
            //{
            //    Nome = "Idílio",
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
