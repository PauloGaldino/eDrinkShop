using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.EPessoas
{
    public class PessoaTipo: Base
    {
        public PessoaTipo()
        {

        }

        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        public int PessoaTipoId { get; set; }
        public ICollection<Pessoa> Pessoas { get; set; }
    }
}
