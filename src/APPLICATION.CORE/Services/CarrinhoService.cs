

using APPLICATION.CORE.Entities;
using APPLICATION.CORE.Entities.CarrinhoAgregado;
using APPLICATION.CORE.Exceptions;
using APPLICATION.CORE.Interfaces;
using APPLICATION.CORE.Specifications;
using Ardalis.GuardClauses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APPLICATION.CORE.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly IAsyncRepository<Carrinho> _carrinhoRepository;
        private readonly IUriComposer _uriComposer;
        private readonly IAppLogger<CarrinhoService> _logger;
        private readonly IRepository<CatalogoItem> _itemRepository;
      

        public CarrinhoService(IAsyncRepository<Carrinho> carrinhoRepository, IRepository<CatalogoItem> itemRepository, IUriComposer uriComposer, IAppLogger<CarrinhoService> logger)
        {
            _carrinhoRepository = carrinhoRepository;
            _uriComposer = uriComposer;
            this._logger = logger;
            _itemRepository = itemRepository;
        }

        public async Task AddItemToCarrinho(int carrinhoId, int catalogoItemId, decimal preco, int quantidade)
        {
            var carrinho = await _carrinhoRepository.GetByIdAsync(carrinhoId);

            carrinho.AddItem(catalogoItemId, preco, quantidade);


            await _carrinhoRepository.UpdateAsync(carrinho);
        }

        public async Task DeleteCarrinhoAsync(int carrinhoId)
        {
            var carrinho = await _carrinhoRepository.GetByIdAsync(carrinhoId);

            await _carrinhoRepository.DeleteAsync(carrinho);
        }


        public async Task<int> GetCarrinhoItemCountAsync(string usuarioNome)
        {
            Guard.Against.NullOrEmpty(usuarioNome, nameof(usuarioNome));
            var carrinhoSpec = new CarrinhoComItemsSpecification(usuarioNome);
            var carrinho = (await _carrinhoRepository.ListAsync(carrinhoSpec)).FirstOrDefault();
            if (carrinho == null)
            {
                _logger.LogInformation($"No basket found for {usuarioNome}");
                return 0;
            }
            int count = carrinho.Items.Sum(i => i.Quantidade);
            _logger.LogInformation($"Basket for {usuarioNome} has {count} items.");
            return count;
        }


        public async Task SetQuantidades(int carrinhoId, Dictionary<string, int> quantidades)
        {
            Guard.Against.Null(quantidades, nameof(quantidades));
            var carrinho = await _carrinhoRepository.GetByIdAsync(carrinhoId);
            Guard.Against.NullCarrinho(carrinhoId, carrinho);
            foreach (var item in carrinho.Items)
            {
                if (quantidades.TryGetValue(item.Id.ToString(), out var quantidade))
                {
                    _logger.LogInformation($"Updating quantity of item ID:{item.Id} to {quantidade}.");
                    item.Quantidade = quantidade;
                }
            }
            await _carrinhoRepository.UpdateAsync(carrinho);
        }

        public async Task TransferCarrinhoAsync(string anonimosId, string usuarioNome)
        {
            Guard.Against.NullOrEmpty(anonimosId, nameof(anonimosId));
            Guard.Against.NullOrEmpty(usuarioNome, nameof(usuarioNome));
            var carrinhoSpec = new CarrinhoComItemsSpecification(anonimosId);
            var carrinho = (await _carrinhoRepository.ListAsync(carrinhoSpec)).FirstOrDefault();
            if (carrinho == null) return;
            carrinho.CompraId = usuarioNome;
            await _carrinhoRepository.UpdateAsync(carrinho);
        }

      
    }
}
