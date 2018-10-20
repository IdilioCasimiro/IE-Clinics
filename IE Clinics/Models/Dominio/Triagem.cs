using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IE_Clinics.Models.Dominio
{
    public class Triagem
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int Peso { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Frequência cardíaca")]
        public int FrenquenciaCardiaca { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Pressão arterial")]
        public int PressaoArterial { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int Temperatura { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Observações")]
        public string Observacoes { get; set; }

        public virtual Marcacao Marcacao { get; set; }
    }
}