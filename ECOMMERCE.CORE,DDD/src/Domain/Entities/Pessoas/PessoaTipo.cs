using ECOMMERCE.ApplicationCore.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Pessoas
{
    public class PessoaTipo : Base
    {
       
       [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        public ICollection<Pessoa> Pessoas { get; set; }
    }
}
