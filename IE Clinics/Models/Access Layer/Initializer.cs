using IE_Clinics.Models.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;

namespace IE_Clinics.Models.Access_Layer
{
    public class Initializer : DropCreateDatabaseIfModelChanges<Contexto>
    {
        CultureInfo cultureInfo = new CultureInfo("pt-AO");
        //O método seed vai carregar dados na BD sempre que esta for criada
        protected override void Seed(Contexto contexto)
        {
            Paciente paciente = new Paciente()
            {
                PrimeiroNome = "Idílio",
                UltimoNome = "Casimiro",
                DataNascimento = DateTime.Parse("23/07/1996", cultureInfo),
                Sexo = Sexo.M,
                Profissao = "Programador",
                Pais = "Angola",
                Provincia = "Luanda",
                Endereco = "Rua 12 de Julho",
                Email = "idiliocasimiro@outlook.com",
                GrupoSanguineo = "A+",
                Telefone = "944446278",
                TelefoneAlternativo = "918014107"
            };

            contexto.Pacientes.Add(paciente);
            contexto.SaveChanges();
            base.Seed(contexto);
        }
    }
}