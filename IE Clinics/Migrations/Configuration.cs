namespace IE_Clinics.Migrations
{
    using IE_Clinics.Models.Dominio;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IE_Clinics.Models.Access_Layer.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "IE_Clinics.Models.Access_Layer.Contexto";
        }

        protected override void Seed(IE_Clinics.Models.Access_Layer.Contexto contexto)
        {
            //Paciente paciente = new Paciente()
            //{
            //    Nome = "Idílio Casimiro",
            //    DataNascimento = DateTime.Parse("23/07/1996"),
            //    Sexo = Sexo.M,
            //    Pais = "Angola",
            //    Provincia = "Luanda",
            //    Endereco = "Rua 12 de Julho",
            //    Email = "idiliocasimiro@outlook.com",
            //    GrupoSanguineo = "A+",
            //    Telefone = "944446278",
            //    TelefoneAlternativo = "918014107"
            //};

            //Especialidade especialidade = new Especialidade()
            //{
            //    Nome = "Cardiologia",
            //    Descricao = "Descrição",
            //    ValorMarcacao = 10250
            //};

            //contexto.Especialidades.Add(especialidade);
            //contexto.SaveChanges();

            //Medico medico = new Medico()
            //{
            //    Nome = "Edson Chinendele",
            //    DataNascimento = DateTime.Parse("01/02/1994"),
            //    Sexo = Sexo.M,
            //    Pais = "Angola",
            //    Provincia = "Luanda",
            //    Endereco = "Zango 0",
            //    Email = "edsonchinendele@ichostweb.com",
            //    GrupoSanguineo = "A+",
            //    Telefone = "944446278",
            //    TelefoneAlternativo = "918014107",
            //    EspecialidadeID = contexto.Especialidades.FirstOrDefault().ID
            //};

            //Medicamento medicamento = new Medicamento()
            //{
            //    Nome = "Omeprazol",
            //    Descricao = "56un"
            //};

            //contexto.Pacientes.Add(paciente);
            //contexto.Medicos.Add(medico);
            //contexto.Medicamentos.Add(medicamento);

            //contexto.SaveChanges();
            //base.Seed(contexto);
        }
    }
}
