using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Pessoas
{
    public class Juridica
    {
        public Juridica()
        {

        }
        //Chave estrangeira
        [Display(Name = "Codigo da Pessoa")]
        public int PessoaId { get; set; }
        //Propriedade de navegação
        public Pessoa Pessoa { get; set; }

        [Display(Name = "Codigo da Pessoa Juridica")]
        public int JuridicaId { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Display(Name = "Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }

        [Display(Name = "Data da Fundação")]
        public DateTime DataFundacao { get; set; }

       
    }
}
