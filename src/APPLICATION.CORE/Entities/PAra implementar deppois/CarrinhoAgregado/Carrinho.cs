using APPLICATION.CORE.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace APPLICATION.CORE.Entities.CarrinhoAgregado
{
    public class Carrinho : BaseEntity, IAggregateRoot
    {

        public string CompraId { get; set; }
        private readonly List<CarrinhoItem> _items = new List<CarrinhoItem>();
        public IReadOnlyCollection<CarrinhoItem> Items => _items.AsReadOnly();

        public void AddItem(int catalogoItemId, decimal precoUnitario, int quantidade = 1)
        {
            if (!Items.Any(i => i.CatalogoItemId == catalogoItemId))
            {
                _items.Add(new CarrinhoItem()
                {
                    CatalogoItemId = catalogoItemId,
                    Quantidade = quantidade,
                    PrecoUnitario = precoUnitario
                });
                return;
            }
            var existingItem = Items.FirstOrDefault(i => i.CatalogoItemId == catalogoItemId);
            existingItem.Quantidade += quantidade;
        }
    }
}
