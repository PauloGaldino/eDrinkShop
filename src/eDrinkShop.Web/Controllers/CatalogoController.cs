using eDrinkShop.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eDrinkShop.Web.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class CatalogoController : Controller
    {
        private readonly ICatalogoService _catalogoService;

        public CatalogoController(ICatalogoService catalogoService) => _catalogoService = catalogoService;

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Index(int? FiltroAplicadoMarcas, int? FiltroAplicadoTipos, int? page)
        {
            var itemsPage = 10;
            var catalogoModel = await _catalogoService.GetCatalogoItems(page ?? 0, itemsPage, FiltroAplicadoMarcas, FiltroAplicadoTipos);
            return View(catalogoModel);
        }

        [HttpGet("Error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
