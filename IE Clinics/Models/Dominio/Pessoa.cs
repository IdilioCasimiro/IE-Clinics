using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IE_Clinics.Models.Dominio
{
    public abstract class Pessoa
    {
        public int ID { get; set; }

        //Informações básicas
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }

        //Endereço
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Endereco { get; set; }

        //Contactos
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Telefone { get; set; }

        public string TelefoneAlternativo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; }
        
        public string GrupoSanguineo { get; set; }
    }

    public enum Sexo { M, F }
}