using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.EPessoas
{
    public class Pessoa : Base
    {
       
       
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        ////Chave estrangeira
        //public int PessoaTipoId { get; set; }
        //public PessoaTipo PessoaTipo { get; set; }

        //public ICollection<Contato> Contatos { get; set; }

        //public ICollection<Cliente> Clientes { get; set; }

       // public ICollection<EnderecoPessoa> EnderecosPessoas { get; set; }

       // public ICollection<ProfissaoPessoa> ProfissaoPessoa { get; set; }
    }
}
