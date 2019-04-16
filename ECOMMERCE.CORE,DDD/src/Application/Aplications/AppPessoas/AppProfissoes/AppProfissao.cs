using System.Collections.Generic;
using Application.Interfaces.IAppPessoas.IAppProfissoes;
using Domain.Entities.Pessoas.Profissoes;
using Domain.Interfaces.IPessoas.IProfissoes;

namespace Application.Aplications.AppPessoas.AppProfissoes
{
    public class AppProfissao : IAppProfissao
    {
         IProfissao _IProfissao;
        public AppProfissao(IProfissao IProfissao)
        {
            _IProfissao = IProfissao;
        }

        public void Adicionar(Profissao Objeto)
        {
            _IProfissao.Adicionar(Objeto);
        }

        public void Atualizar(Profissao Objeto)
        {
            _IProfissao.Atualizar(Objeto);
        }

        public void Excluir(Profissao Objeto)
        {
            _IProfissao.Excluir(Objeto);
        }

        public IList<Profissao> Listar()
        {
            return _IProfissao.Listar();
        }

        public Profissao ObterPorId(int Id)
        {
            return _IProfissao.ObterPorId(Id);
        }
    }
}
