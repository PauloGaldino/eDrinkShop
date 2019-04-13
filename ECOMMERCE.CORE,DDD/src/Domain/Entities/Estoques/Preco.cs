namespace Domain.Entities.Estoques
{
    public class Preco
    {
        public Preco()
        {

        }
        public int Id { get; set; }
        public decimal Precos { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
