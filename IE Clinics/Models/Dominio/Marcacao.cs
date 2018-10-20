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
        public EstadoMarcacao Estado { get; set; }

        public int PacienteID { get; set; }
        public int MedicoID { get; set; }

        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }

        #region Relacionamentos da Análise médica
        public virtual Triagem Triagem { get; set; }
        public virtual AnaliseMedica AnaliseMedica { get; set; }
        public virtual Prescricao Prescricao { get; set; }
        #endregion
    }

    public enum EstadoMarcacao
    {
        Agendado,
        Reagendado,
        Paciente_Atendido,
        Paciente_Faltou,
        Aguardando_Atendimento
    }
}