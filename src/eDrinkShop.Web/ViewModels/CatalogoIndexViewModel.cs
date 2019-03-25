using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace eDrinkShop.Web.ViewModels
{
    public class CatalogoIndexViewModel
    {
        public IEnumerable<CatalogoItemViewModel> CatalogoItems { get; set; }
        public IEnumerable<SelectListItem> Marcas { get; set; }
        public IEnumerable<SelectListItem> Tipos { get; set; }
        public int? FiltroAplicadoMarcas { get; set; }
        public int? FiltoroAplicadoTipos { get; set; }
        public PaginacaoInfoViewModel PaginacaoInfo { get; set; }
    }
}
