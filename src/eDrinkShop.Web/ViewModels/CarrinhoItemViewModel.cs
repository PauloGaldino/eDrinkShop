namespace eDrinkShop.Web.ViewModels
{
    public class CarrinhoItemViewModel
    {

        public int Id { get; set; }
        public int CatalogoItemId { get; set; }
        public string ProdutoNome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal PrecoUnitarioAntigo { get; set; }
        public int Quantidade { get; set; }
        public string FotoUrl { get; set; }
    }
}
