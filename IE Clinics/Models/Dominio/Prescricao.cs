using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IE_Clinics.Models.Dominio
{
    public class Prescricao
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public List<Medicamento> Medicamento { get; set; }

        //[Required(ErrorMessage = "Campo obrigatório")]
        //public string Posologia { get; set; }

        //[Required(ErrorMessage = "Campo obrigatório")]
        //public int Quantidade { get; set; }

        public virtual Marcacao Marcacao { get; set; }
    }
}