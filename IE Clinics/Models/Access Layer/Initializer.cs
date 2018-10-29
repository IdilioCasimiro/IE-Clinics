using IE_Clinics.Models.Dominio;
using System;
using System.Data.Entity;
using System.Globalization;
using System.Linq;

namespace IE_Clinics.Models.Access_Layer
{
    public class Initializer : CreateDatabaseIfNotExists<Contexto>
    {
        CultureInfo cultureInfo = new CultureInfo("pt-AO");
        //O método seed vai carregar dados na BD sempre que esta for criada
        protected override void Seed(Contexto contexto)
        {
            Paciente paciente = new Paciente()
            {
                Nome = "Idílio Casimiro",
                DataNascimento = DateTime.Parse("23/07/1996", cultureInfo),
                Sexo = Sexo.M,
                Pais = "Angola",
                Provincia = "Luanda",
                Endereco = "Rua 12 de Julho",
                Email = "idiliocasimiro@outlook.com",
                GrupoSanguineo = "A+",
                Telefone = "944446278",
                TelefoneAlternativo = "918014107"
            };

            Especialidade especialidade = new Especialidade()
            {
                Nome = "Cardiologia",
                Descricao = "Descrição",
                ValorMarcacao = 10250
            };

            contexto.Especialidades.Add(especialidade);
            contexto.SaveChanges();

            Medico medico = new Medico()
            {
                Nome = "Edson Chinendele",
                DataNascimento = DateTime.Parse("01/02/1994", cultureInfo),
                Sexo = Sexo.M,
                Pais = "Angola",
                Provincia = "Luanda",
                Endereco = "Zango 0",
                Email = "edsonchinendele@ichostweb.com",
                GrupoSanguineo = "A+",
                Telefone = "944446278",
                TelefoneAlternativo = "918014107",
                EspecialidadeID = contexto.Especialidades.FirstOrDefault().ID
            };

            Medicamento medicamento = new Medicamento()
            {
                Nome = "Omeprazol",
                Descricao = "56un"
            };

            contexto.Pacientes.Add(paciente);
            contexto.Medicos.Add(medico);
            contexto.Medicamentos.Add(medicamento);

            contexto.SaveChanges();
            base.Seed(contexto);
        }
    }
}