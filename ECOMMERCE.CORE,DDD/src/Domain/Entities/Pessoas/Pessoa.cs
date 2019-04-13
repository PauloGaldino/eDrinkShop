
using Domain.Entities.Contatos;
using Domain.Entities.Profissoes;
using System.Collections.Generic;

namespace Domain.Entities.Pessoas
{
    public class Pessoa
    {
        public Pessoa()
        {

        }

        //Chave estrangeira
        public int PessoaTipoId { get; set; }
        public PessoaTipo PessoaTipo { get; set; }

        public int PessoaId { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }

      

        public ICollection<Contato>  Contatos{ get; set; }

        public ICollection<Cliente> Clientes { get; set; }

        public ICollection<EnderecoPessoa> EnderecosPessoas { get; set; }

        public ICollection<ProfissaoPessoa> ProfissaoPessoa { get; set; }
    }
}
