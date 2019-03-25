using APPLICATION.CORE.Entities.CarrinhoAgregado;
using Ardalis.GuardClauses;

namespace APPLICATION.CORE.Exceptions
{
    public static class GuardException
    {
        public static void NullCarrinho(this IGuardClause guardClause, int carrinhoId, Carrinho carrinho)
        {
            if (carrinho == null)
                throw new CarrinhoNaoEncontradoException(carrinhoId);
        }
    }

}
