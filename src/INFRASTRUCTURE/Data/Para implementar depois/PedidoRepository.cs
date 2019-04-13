using APPLICATION.CORE.Entities.PedidoAgregado;
using APPLICATION.CORE.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Data
{
    public class PedidoRepository : EfRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(CatalogoContext dbContext) : base(dbContext)
        {
        }

        public Pedido GetByIdComItems(int id)
        {
            return _dbContext.Pedidos
                .Include(o => o.PedidoItems)
                .Include($"{nameof(Pedido.PedidoItems)}.{nameof(PedidoItem.ItemPedido)}")
                .FirstOrDefault();
        }

        public Task<Pedido> GetByIdComItemsAsync(int id)
        {
            return _dbContext.Pedidos
                .Include(o => o.PedidoItems)
                .Include($"{nameof(Pedido.PedidoItems)}.{nameof(PedidoItem.ItemPedido)}")
                .FirstOrDefaultAsync();
        }
    }
}