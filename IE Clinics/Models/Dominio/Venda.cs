using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IE_Clinics.Models.Dominio
{
    public class Venda
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Nome do cliente")]
        public string NomeCliente { get; set; }

        public string Farmaco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Valor total")]
        public int ValorTotal { get; set; }
    }
}