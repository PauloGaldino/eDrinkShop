using System.Collections.Generic;
using APPLICATION.CORE.Entities;
using APPLICATION.CORE.Interfaces.Produtos;
using APPLICATION.interfaces;

namespace APPLICATION.Application
{
    public class AppProduto : IAppProduto
    {
        IProduto _IProduto;
        public AppProduto(IProduto IProduto)
        {
            _IProduto = IProduto;
        }
        public void Adcionar(Produto Objeto)
        {
            _IProduto.Adcionar(Objeto);
        }

        public void Atualizar(Produto Objeto)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(Produto Objeto)
        {
            throw new System.NotImplementedException();
        }

        public IList<Produto> Listar()
        {
            throw new System.NotImplementedException();
        }

        public Produto ObterPorId(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
