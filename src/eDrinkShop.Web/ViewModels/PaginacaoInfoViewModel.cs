namespace eDrinkShop.Web.ViewModels
{
    public class PaginacaoInfoViewModel
    {
        public int TotalItems { get; set; }
        public int ItemsPorPaginas { get; set; }
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public string Anterior { get; set; }
        public string Proxima { get; set; }
    }
}
