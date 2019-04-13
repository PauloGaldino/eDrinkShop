using ECOMMERCE.ApplicationCore.Entities;
using System.Collections.Generic;

namespace Domain.Entities.Pessoas
{
    public class PessoaTipo : Base
    {
       
       
        public string Descricao { get; set; }

        public ICollection<Pessoa> Pessoas { get; set; }




    }
}
