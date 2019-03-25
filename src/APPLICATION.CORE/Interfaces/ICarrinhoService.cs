using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPLICATION.CORE.Interfaces
{
    public interface ICarrinhoService
    {

        Task<int> GetCarrinhoItemCountAsync(string usuarioNome);
        Task TransferCarrinhoAsync(string anonimosId, string usuarioNome);
        Task AddItemToCarrinho(int carrinhoId, int catalogoItemId, decimal preco, int quantidade);
        Task SetQuantidades(int carrinhoId, Dictionary<string, int> quantidades);
        Task DeleteCarrinhoAsync(int carrinhoId);
    }
}
