using eDrinkShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDrinkShop.Web.Interfaces
{
    public interface ICatalogoService 
    {
        Task<CatalogoIndexViewModel> GetCatalogoItems(int pageIndex, int itemsPage, int? marcaId, int? tipoId);
        Task<IEnumerable<SelectListItem>> GetMarcas();
        Task<IEnumerable<SelectListItem>> GetTipos();
    }
}
