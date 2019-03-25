namespace APPLICATION.CORE.Entities.PedidoAgregado
{
    public class PedidoItem : BaseEntity
    {
        public CatalogoItemPedido ItemPedido { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public int Unidades { get; private set; }

        private PedidoItem()
        {
            // required by EF
        }

        public PedidoItem(CatalogoItemPedido pedidoItem, decimal precoUnitario, int unidades)
        {
            ItemPedido = pedidoItem;
            PrecoUnitario = precoUnitario;
            Unidades = unidades;
        }
    }
}
