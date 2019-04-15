using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Pessoas
{
    public class Fisica
    {
        public Fisica()
        {

        }

        //Chave estrangeria
        [Display(Name = "Codigo da Pessoa")]
        public int PessoaId { get; set; }

        //Propriedade de navegação
        public Pessoa Pessoa { get; set; }

        [Display(Name = "Codigo da Pessoa Física")]
        public int FisicaId { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Display(Name = "RG")]
        public string Rg { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

    }
}
