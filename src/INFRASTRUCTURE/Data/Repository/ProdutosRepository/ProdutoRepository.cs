using System.Collections.Generic;
using APPLICATION.CORE.Entities;
using APPLICATION.CORE.Interfaces.Generic;
using APPLICATION.CORE.Interfaces.Produtos;
using INFRASTRUCTURE.Data.Repository.GenericRepository;

namespace INFRASTRUCTURE.Data.Repository.ProdutosRepository
{
    public class ProdutoRepository : GenericRepository<Produto>, IProduto
    {
        public void Adcionar(IProduto Objeto)
        {
            throw new System.NotImplementedException();
        }

        public void Atualizar(IProduto Objeto)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(IProduto Objeto)
        {
            throw new System.NotImplementedException();
        }

        IList<IProduto> IGenerichal<IProduto>.Listar()
        {
            throw new System.NotImplementedException();
        }

        IProduto IGenerichal<IProduto>.ObterPorId(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
