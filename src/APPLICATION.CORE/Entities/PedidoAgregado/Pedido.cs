using APPLICATION.CORE.Interfaces;
using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;

namespace APPLICATION.CORE.Entities.PedidoAgregado
{
   public class Pedido : BaseEntity, IAggregateRoot
    {
        private Pedido()
        {
            // required by EF
        }

        public Pedido(string compraId, Endereco shipToEndereco, List<PedidoItem> items)
        {
            Guard.Against.NullOrEmpty(compraId, nameof(CompraId));
            Guard.Against.Null(shipToEndereco, nameof(shipToEndereco));
            Guard.Against.Null(items, nameof(items));

            CompraId = compraId;
            ShipToEndereco = shipToEndereco;
            _pedidoItems = items;
        }
        public string CompraId { get; private set; }

        public DateTimeOffset PedidoData { get; private set; } = DateTimeOffset.Now;
        public Endereco ShipToEndereco { get; private set; }

        // DDD Patterns comment
        // Using a private collection field, better for DDD Aggregate's encapsulation
        // so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
        // but only through the method Pedido.AddPedidoItem() which includes behavior.

        private readonly List<PedidoItem> _pedidoItems = new List<PedidoItem>();

        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems.AsReadOnly();
        
        // Using List<>.AsReadOnly() 
        // This will create a read only wrapper around the private list so is protected against "external updates".
        // It's much cheaper than .ToList() because it will not have to copy all items in a new collection. (Just one heap alloc for the wrapper instance)
        //https://msdn.microsoft.com/en-us/library/e78dcd75(v=vs.110).aspx 

        public decimal Total()
        {
            var total = 0m;
            foreach (var item in _pedidoItems)
            {
                total += item.PrecoUnitario * item.Unidades;
            }
            return total;
        }

    }
}
