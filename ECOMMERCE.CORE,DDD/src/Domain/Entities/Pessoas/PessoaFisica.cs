using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Pessoas
{
    public class PessoaFisica
    {
        public PessoaFisica()
        {

        }
        [Display(Name ="Código da Pessoa Física")]
        public int PessoaFisicaId { get; set; }

    }
}
