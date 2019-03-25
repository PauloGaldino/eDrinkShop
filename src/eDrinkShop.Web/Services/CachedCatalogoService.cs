using eDrinkShop.Web.Interfaces;
using eDrinkShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDrinkShop.Web.Services
{
    public class CachedCatalogoService : ICatalogoService
    {
        private readonly IMemoryCache _cache;
        private readonly CatalogoService _catalogoService;
        private static readonly string _marcasKey = "marcas";
        private static readonly string _tiposKey = "tipos";
        private static readonly string _itemsKeyTemplate = "items-{0}-{1}-{2}-{3}";
        private static readonly TimeSpan _defaultCacheDuration = TimeSpan.FromSeconds(30);

        public CachedCatalogoService(IMemoryCache cache,
           CatalogoService catalogoService)
        {
            _cache = cache;
            _catalogoService = catalogoService;
        }

        public async Task<IEnumerable<SelectListItem>> GetMarcas()
        {
            return await _cache.GetOrCreateAsync(_marcasKey, async entry =>
            {
                entry.SlidingExpiration = _defaultCacheDuration;
                return await _catalogoService.GetMarcas();
            });
        }

        public async Task<CatalogoIndexViewModel> GetCatalogoItems(int pageIndex, int itemsPage, int? marcaId, int? tipoId)
        {
            string cacheKey = String.Format(_itemsKeyTemplate, pageIndex, itemsPage, marcaId, tipoId);
            return await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.SlidingExpiration = _defaultCacheDuration;
                return await _catalogoService.GetCatalogoItems(pageIndex, itemsPage, marcaId, tipoId);
            });
        }

        public async Task<IEnumerable<SelectListItem>> GetTipos()
        {
            return await _cache.GetOrCreateAsync(_tiposKey, async entry =>
            {
                entry.SlidingExpiration = _defaultCacheDuration;
                return await _catalogoService.GetTipos();
            });
        }

    }
}
