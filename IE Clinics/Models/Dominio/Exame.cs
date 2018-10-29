using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IE_Clinics.Models.Dominio
{
    public class Exame
    {
        public int ExameID { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int Valor { get; set; }

        public List<AnaliseMedica> AnalisesMedicas { get; set; }

    }
}