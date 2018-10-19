using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IE_Clinics.Models.Dominio
{
    public class Medico : Pessoa
    {
        public int EspecialidadeID { get; set; }
        public Especialidade Especialidade { get; set; }

        public List<Marcacao> Marcacoes { get; set; }
    }
}