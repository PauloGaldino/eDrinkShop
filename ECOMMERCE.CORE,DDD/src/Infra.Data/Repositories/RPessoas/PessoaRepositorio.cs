using Domain.Entities.Pessoas;
using Domain.Interfaces.IPessoas;

namespace Infra.Data.Repositories.RPessoas
{
    public  class PessoaRepositorio : RepositorioGenerico<Pessoa>, IPessoa
    {
    }
}
