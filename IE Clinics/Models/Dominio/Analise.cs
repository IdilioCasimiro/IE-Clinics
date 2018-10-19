using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IE_Clinics.Models.Dominio
{
    public class Analise
    {
        public int Peso { get; set; }
        public int BatimentosCardiacos { get; set; }
        public int Acucar { get; set; }
        public int Pressao { get; set; }
        public string Observacoes { get; set; }
    }
}