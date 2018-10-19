using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IE_Clinics.Models.Dominio
{
    public class MarcacaoCalendario
    {
        public int ID { get; set; }
        public string TipoMarcacao { get; set; } //Consulta, Exame ou revisão
        public string Especialidade { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public int Duracao { get; set; }
        public string Observacao { get; set; }
        public string Paciente { get; set; }
        public string Medico { get; set; }
    }
}