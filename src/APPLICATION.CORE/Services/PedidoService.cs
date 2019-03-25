using APPLICATION.CORE.Entities;
using APPLICATION.CORE.Entities.CarrinhoAgregado;
using APPLICATION.CORE.Entities.PedidoAgregado;
using APPLICATION.CORE.Exceptions;
using APPLICATION.CORE.Interfaces;
using Ardalis.GuardClauses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPLICATION.CORE.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IAsyncRepository<Pedido> _pedidoRepository;
        private readonly IAsyncRepository<Carrinho> _carrinhoRepository;
        private readonly IAsyncRepository<CatalogoItem> _itemRepository;

        public PedidoService(IAsyncRepository<Carrinho> carrinhoRepository,
            IAsyncRepository<CatalogoItem> itemRepository,
            IAsyncRepository<Pedido> pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoRepository = carrinhoRepository;
            _itemRepository = itemRepository;
        }

        public async Task CreatePedidoAsync(int carrinhoId, Endereco shippingEndereco)
        {
            var carrinho = await _carrinhoRepository.GetByIdAsync(carrinhoId);
            Guard.Against.NullCarrinho(carrinhoId, carrinho);
            var items = new List<PedidoItem>();
            foreach (var item in carrinho.Items)
            {
                var catalogoItem = await _itemRepository.GetByIdAsync(item.CatalogoItemId);
                var itemPedido = new CatalogoItemPedido(catalogoItem.Id, catalogoItem.Nome, catalogoItem.FotoUri);
                var pedidoItem = new PedidoItem(itemPedido, item.PrecoUnitario, item.Quantidade);
                items.Add(pedidoItem);
            }
            var pedido = new Pedido(carrinho.CompraId, shippingEndereco, items);

            await _pedidoRepository.AddAsync(pedido);
        }
    }
}