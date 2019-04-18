using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Validations
{
   public class ValidarExcepton :Exception
    {
        public readonly Expression<Func<object, object>> _objeto = x => x;
        protected IList<ViolacaoValidar> _Erro = new List<ViolacaoValidar>();

        protected void AdicionarMensagenErro(string Mensagem)
        {
            _Erro.Add(new ViolacaoValidar { Propriedade = _objeto, Mensagem = Mensagem });
        }
    }
}
