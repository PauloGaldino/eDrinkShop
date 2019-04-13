using Ardalis.GuardClauses;

namespace APPLICATION.CORE.Entities.PedidoAgregado
{
    public class CatalogoItemPedido
    {
        public CatalogoItemPedido(int catalogoItemId, string produtoNome, string fotoUri)
        {
            Guard.Against.OutOfRange(catalogoItemId, nameof(catalogoItemId), 1, int.MaxValue);
            Guard.Against.NullOrEmpty(produtoNome, nameof(produtoNome));
            Guard.Against.NullOrEmpty(fotoUri, nameof(fotoUri));

            CatalogoItemId = catalogoItemId;
            ProdutoNome = produtoNome;
            FotoUri = fotoUri;
        }

        private CatalogoItemPedido()
        {
            // required by EF
        }

        public int CatalogoItemId { get; private set; }
        public string ProdutoNome { get; private set; }
        public string FotoUri { get; private set; }
    }
}
