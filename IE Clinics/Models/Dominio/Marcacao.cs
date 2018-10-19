using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace IE_Clinics.Models.Dominio
{
    public class Marcacao
    {
        public int ID { get; set; }
        public string TipoMarcacao { get; set; } //Consulta, Exame ou revisão
        public string Especialidade { get; set; }
        public DateTime Data { get; set; }
        public int Duracao { get; set; }
        public string Observacao { get; set; }

        public int PacienteID { get; set; }
        public int MedicoID { get; set; }

        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
    }
}