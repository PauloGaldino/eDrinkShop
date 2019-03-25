using eDrinkShop.Web.ViewModels;
using System.Threading.Tasks;

namespace eDrinkShop.Web.Interfaces
{
    public interface ICarrinhoViewModelService
    {
        Task<CarrinhoViewModel> GetOrCreateCarrinhoForUser(string usuarioNome);
    }
}
