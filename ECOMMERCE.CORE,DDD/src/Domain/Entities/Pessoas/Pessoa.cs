using Domain.Entities.Contatos;
using Domain.Entities.Pessoas.Profissoes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Pessoas
{
    public class Pessoa
    {
        public Pessoa()
        {

        }
        
        //Chave estrangeira
        [Display(Name ="Codigo da PessoaTipo")]
        public int PessoaTipoId { get; set; }
        public PessoaTipo PessoaTipo { get; set; }

        [Display(Name = "Codigo da Pessoa")]
        public int PessoaId { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

      

        public ICollection<Contato>  Contatos{ get; set; }

        public ICollection<Cliente> Clientes { get; set; }

        public ICollection<EnderecoPessoa> EnderecosPessoas { get; set; }
        public ICollection<EnderecoCliente> EnderecoClientes { get; set; }
        public ICollection<ProfissaoPessoa> ProfissaoPessoa { get; set; }


    }
}
