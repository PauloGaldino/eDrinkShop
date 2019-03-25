using APPLICATION.CORE.Entities;
using APPLICATION.CORE.Interfaces;
using APPLICATION.CORE.Specifications;
using eDrinkShop.Web.Interfaces;
using eDrinkShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDrinkShop.Web.Services
{
    public class CatalogoService : ICatalogoService
    {
        private readonly ILogger<CatalogoService> _logger;
        private readonly IRepository<CatalogoItem> _itemRepository;
        private readonly IAsyncRepository<CatalogoMarca> _marcaRepository;
        private readonly IAsyncRepository<CatalogoTipo> _tipoRepository;
        private readonly IUriComposer _uriComposer;

        public CatalogoService(
            ILoggerFactory loggerFactory,
            IRepository<CatalogoItem> itemRepository,
            IAsyncRepository<CatalogoMarca> marcaRepository,
            IAsyncRepository<CatalogoTipo> tipoRepository,
            IUriComposer uriComposer)
        {
            _logger = loggerFactory.CreateLogger<CatalogoService>();
            _itemRepository = itemRepository;
            _marcaRepository = marcaRepository;
            _tipoRepository = tipoRepository;
            _uriComposer = uriComposer;
        }

        public async Task<CatalogoIndexViewModel> GetCatalogoItems(int pageIndex, int itemsPage, int? marcaId, int? tipoId)
        {
            _logger.LogInformation("GetCatalogItems called.");

            var filterSpecification = new CatalogoSpecification(marcaId, tipoId);
            var filterPaginatedSpecification =
 new CatalogoFilterPaginatedSpecification(itemsPage * pageIndex, itemsPage, marcaId, tipoId);

            // the implementation below using ForEach and Count. We need a List.
            var itemsOnPage = _itemRepository.List(filterPaginatedSpecification).ToList();
            var totalItems = _itemRepository.Count(filterSpecification);

            itemsOnPage.ForEach(x =>
            {
                x.FotoUri = _uriComposer.ComposeFotUri(x.FotoUri);
            });

            var vm = new CatalogoIndexViewModel()
            {
                CatalogoItems = itemsOnPage.Select(i => new CatalogoItemViewModel()
                {
                    Id = i.Id,
                    Nome = i.Nome,
                    FotoUri = i.FotoUri,
                    Preco = i.Preco
                }),
                Marcas = await GetMarcas(),
                Tipos = await GetTipos(),
                FiltroAplicadoMarcas = marcaId ?? 0,
               FiltoroAplicadoTipos = tipoId ?? 0,
                PaginacaoInfo = new PaginacaoInfoViewModel()
                {
                    PaginaAtual = pageIndex,
                    ItemsPorPaginas = itemsOnPage.Count,
                    TotalItems = totalItems,
                    TotalPaginas = int.Parse(Math.Ceiling(((decimal)totalItems / itemsPage)).ToString())
                }
            };

            vm.PaginacaoInfo.Proxima = (vm.PaginacaoInfo.PaginaAtual == vm.PaginacaoInfo.TotalPaginas - 1) ? "is-disabled" : "";
            vm.PaginacaoInfo.Anterior = (vm.PaginacaoInfo.PaginaAtual == 0) ? "is-disabled" : "";

            return vm;
        }

        public async Task<IEnumerable<SelectListItem>> GetMarcas()
        {
            _logger.LogInformation("GetMarcass called.");
            var marcas = await _marcaRepository.ListAllAsync();

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            foreach (CatalogoMarca marca in marcas)
            {
                items.Add(new SelectListItem() { Value = marca.Id.ToString(), Text = marca.Marca });
            }

            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetTipos()
        {
            _logger.LogInformation("GetTipos called.");
            var tipos = await _tipoRepository.ListAllAsync();
            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            foreach (CatalogoTipo tipo in tipos)
            {
                items.Add(new SelectListItem() { Value = tipo.Id.ToString(), Text = tipo.Tipo });
            }

            return items;
        }
    }
}
