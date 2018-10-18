using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace IE_Clinics.Models.Dominio
{


    public class Paciente
    {
        public int ID { get; set; }

        //Informações básicas
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public string Profissao { get; set; }

        //Endereço
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Endereco { get; set; }

        //Contactos
        public string Telefone { get; set; }
        public string TelefoneAlternativo { get; set; }
        public string Email { get; set; }

        //Dados de saúde
        public string GrupoSanguineo { get; set; }
        //public int Peso { get; set; }
        //public int BatimentosCardiacos { get; set; }
        //public int Acucar { get; set; }
        //public int Pressao { get; set; }

    }

    public enum Sexo { M, F }
}