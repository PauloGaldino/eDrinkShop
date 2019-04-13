

using APPLICATION.CORE.Entities.PedidoAgregado;
using System.Threading.Tasks;

namespace APPLICATION.CORE.Interfaces
{
    public interface IPedidoService
    {
        Task CreatePedidoAsync(int carrinhoId, Endereco shippingEndereco);
    }
}
