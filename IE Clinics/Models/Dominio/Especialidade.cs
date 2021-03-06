﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IE_Clinics.Models.Dominio
{
    public class Especialidade
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int ValorMarcacao { get; set; }

        public List<Medico> Medicos { get; set; }
    }
}