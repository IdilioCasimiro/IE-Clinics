﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace IE_Clinics.Models.Dominio
{


    public class Paciente : Pessoa
    {
        public List<Marcacao> Marcacoes { get; set; }
    }
}