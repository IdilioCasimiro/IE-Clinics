﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IE_Clinics.Models.Dominio
{
    public class AnaliseMedica
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Indicação clínica")]
        public string IndicacaoClinica { get; set; }

        public List<Exame> Exames { get; set; }
        
        public virtual Marcacao Marcacao { get; set; }
    }
}