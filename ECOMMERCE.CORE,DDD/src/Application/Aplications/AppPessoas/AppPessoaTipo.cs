using System.Collections.Generic;
using Application.Interfaces.IAppPessoas;
using Domain.Entities.Pessoas;
using Domain.Interfaces.IPessoas;

namespace Application.Aplications.AppPessoas
{
    public class AppPessoaTipo : IAppPessoaTipo
    {
        IPessoaTipo _IPessoaTipo;
        public AppPessoaTipo(IPessoaTipo IPessoaTipo)
        {
            _IPessoaTipo = IPessoaTipo;

        }

        public void Adicionar(PessoaTipo Objeto)
        {
            _IPessoaTipo.Adicionar(Objeto);
        }

        public void Atualizar(PessoaTipo Objeto)
        {
            _IPessoaTipo.Atualizar(Objeto);
        }

        public void Excluir(PessoaTipo Objeto)
        {
            _IPessoaTipo.Excluir(Objeto);
        }

        public IList<PessoaTipo> Listar()
        {
           return _IPessoaTipo.Listar();
        }

        public PessoaTipo ObterPorId(int Id)
        {
            return _IPessoaTipo.ObterPorId(Id);
        }
    }
}
