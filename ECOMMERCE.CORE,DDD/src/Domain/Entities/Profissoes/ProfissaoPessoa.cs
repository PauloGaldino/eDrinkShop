using Domain.Entities.Pessoas;

namespace Domain.Entities.Profissoes
{
    public class ProfissaoPessoa
    {
        public int Id { get; set; }

        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public int ProfissaoId { get; set; }
        public Profissao Profissao { get; set; }
    }
}
