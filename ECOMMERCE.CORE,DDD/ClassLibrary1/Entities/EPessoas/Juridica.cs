using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.EPessoas
{
    public class Juridica : Base
    {
        [Display(Name ="Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Numero do CNPJ")]
        public string Cnpj { get; set; }

        [Display(Name = "Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }

        [Display(Name = "Data da Fundação")]
        public DateTime DataFundacao { get; set; }
    }
}
 