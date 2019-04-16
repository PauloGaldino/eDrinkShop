using System.Collections.Generic;
using Application.Interfaces.IAppPessoas;
using Domain.Entities.Pessoas;
using Domain.Interfaces.IPessoas;

namespace Application.Aplications.AppPessoas
{
    public class AppPessoa : IAppPessoa
    {
        IPessoa _IPessoa;
        public AppPessoa(IPessoa IPessoa)
        {
            _IPessoa = IPessoa;
        }

        public void Adicionar(Pessoa Objeto)
        {
            _IPessoa.Adicionar(Objeto);
        }

        public void Atualizar(Pessoa Objeto)
        {
            _IPessoa.Atualizar(Objeto);
        }

        public void Excluir(Pessoa Objeto)
        {
            _IPessoa.Excluir(Objeto);
        }

        public IList<Pessoa> Listar()
        {
            return _IPessoa.Listar();
        }

        public Pessoa ObterPorId(int Id)
        {
            return _IPessoa.ObterPorId(Id);
        }
    }
}
