using APPLICATION.CORE.Entities.CarrinhoAgregado;

namespace APPLICATION.CORE.Specifications
{
    public class CarrinhoComItemsSpecification : BaseSpecification<Carrinho>
    {
        public CarrinhoComItemsSpecification(int carrinhoId)
            :base(b => b.Id == carrinhoId)
        {
            AddInclude(b => b.Items);
        }
        public CarrinhoComItemsSpecification( string compraId)
            :base(b => b.CompraId == compraId)
        {
            AddInclude(b => b.Items);
        }
    }
}
