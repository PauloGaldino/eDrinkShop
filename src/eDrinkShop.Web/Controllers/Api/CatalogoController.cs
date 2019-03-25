using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eDrinkShop.Web.Interfaces;
using eDrinkShop.Web.Services;

namespace eDrinkShop.Web.Controllers.Api
{
    public class CatalogoController : Controller
    {

        private readonly ICatalogoService _catalogoService;

        public CatalogoController(CatalogoService catalogoService) => _catalogoService = catalogoService;

        [HttpGet]
        public async Task<IActionResult> List(int? FiltroAplicadoMarcas, int? FiltroAplicadoTipos, int? page)
        {
            var itemsPage = 10;
            var catalogoModel = await _catalogoService.GetCatalogoItems(page ?? 0, itemsPage, FiltroAplicadoMarcas, FiltroAplicadoTipos);
            return Ok(catalogoModel);
        }
    }
}
