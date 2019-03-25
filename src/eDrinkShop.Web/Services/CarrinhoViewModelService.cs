using APPLICATION.CORE.Entities;
using APPLICATION.CORE.Entities.CarrinhoAgregado;
using APPLICATION.CORE.Interfaces;
using APPLICATION.CORE.Specifications;
using eDrinkShop.Web.Interfaces;
using eDrinkShop.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDrinkShop.Web.Services
{
    public class CarrinhoViewModelService : ICarrinhoViewModelService
    {
        private readonly IAsyncRepository<Carrinho> _carrinhoRepository;
        private readonly IUriComposer _uriComposer;
        private readonly IRepository<CatalogoItem> _itemRepository;

        public CarrinhoViewModelService(IAsyncRepository<Carrinho> carrinhoRepository,
            IRepository<CatalogoItem> itemRepository,
            IUriComposer uriComposer)
        {
            _carrinhoRepository = carrinhoRepository;
            _uriComposer = uriComposer;
            _itemRepository = itemRepository;
        }

        public async Task<CarrinhoViewModel> GetOrCreateCarrinhoForUser(string usuarioNome)
        {
            var carrinhoSpec = new CarrinhoComItemsSpecification(usuarioNome);
            var carrinho = (await _carrinhoRepository.ListAsync(carrinhoSpec)).FirstOrDefault();

            if (carrinho == null)
            {
                return await CreateCarrinhoForUser(usuarioNome);
            }
            return CreateViewModelFromCarrinho(carrinho);
        }

        private CarrinhoViewModel CreateViewModelFromCarrinho(Carrinho carrinho)
        {
            var viewModel = new CarrinhoViewModel();
            viewModel.Id = carrinho.Id;
            viewModel.CompraId = carrinho.CompraId;
            viewModel.Items = carrinho.Items.Select(i =>
            {
                var itemModel = new CarrinhoItemViewModel()
                {
                    Id = i.Id,
                    PrecoUnitario = i.PrecoUnitario,
                    Quantidade = i.Quantidade,
                    CatalogoItemId = i.CatalogoItemId

                };
                var item = _itemRepository.GetById(i.CatalogoItemId);
                itemModel.FotoUrl = _uriComposer.ComposeFotUri(item.FotoUri);
                itemModel.ProdutoNome = item.Nome;
                return itemModel;
            })
                            .ToList();
            return viewModel;
        }

        private async Task<CarrinhoViewModel> CreateCarrinhoForUser(string usuarioId)
        {
            var carrinho = new Carrinho() { CompraId = usuarioId };
            await _carrinhoRepository.AddAsync(carrinho);

            return new CarrinhoViewModel()
            {
                CompraId = carrinho.CompraId,
                Id = carrinho .Id,
                Items = new List<CarrinhoItemViewModel>()
            };
        }

      
    }
}