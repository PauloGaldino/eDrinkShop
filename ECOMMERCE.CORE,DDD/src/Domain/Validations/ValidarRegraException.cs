using System;
using System.Linq.Expressions;

namespace Domain.Validations
{
    public class ValidarRegraException<T> : ValidarExcepton
    {
        internal void AdidionarErroPara<TPropriedade>(Expression<Func<T,TPropriedade>> propriedade, string mensagem)
        {
            _Erro.Add(new ViolacaoValidar {Propriedade = propriedade, Mensagem = mensagem });
        }
    }
}
