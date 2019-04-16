using System.Collections.Generic;
using Application.Interfaces.IAppPessoas.IAppProfissoes;
using Domain.Entities.Pessoas.Profissoes;
using Domain.Interfaces.IPessoas.IProfissoes;

namespace Application.Aplications.AppPessoas.AppProfissoes
{
   public class AppProfissaoPessoa : IAppProfissaoPessoa
    {
        IProfissaoPessoa _IProfissaoPessoa;
        public AppProfissaoPessoa(IProfissaoPessoa IProfissaoPessoa)
        {
            _IProfissaoPessoa = IProfissaoPessoa;
        }

        public void Adicionar(ProfissaoPessoa Objeto)
        {
            _IProfissaoPessoa.Adicionar(Objeto);
        }

        public void Atualizar(ProfissaoPessoa Objeto)
        {
            _IProfissaoPessoa.Atualizar(Objeto);
        }

        public void Excluir(ProfissaoPessoa Objeto)
        {
            _IProfissaoPessoa.Excluir(Objeto);
        }

        public IList<ProfissaoPessoa> Listar()
        {
            return _IProfissaoPessoa.Listar();
        }

        public ProfissaoPessoa ObterPorId(int Id)
        {
            return _IProfissaoPessoa.ObterPorId(Id);
        }
    }
}
