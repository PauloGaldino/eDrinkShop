using APPLICATION.CORE.Entities.PedidoAgregado;
using System.Threading.Tasks;

namespace APPLICATION.CORE.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>, IAsyncRepository<Pedido>
    {
        Pedido GetByIdComItems(int id);
        Task<Pedido> GetByIdComItemsAsync(int id);
    }
}
