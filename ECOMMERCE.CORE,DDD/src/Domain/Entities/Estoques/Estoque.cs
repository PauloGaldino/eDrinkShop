namespace Domain.Entities.Estoques
{
    public class Estoque
    {
        public Estoque()
        {
                
        }
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
