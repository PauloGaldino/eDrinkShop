using System.Linq.Expressions;

namespace Domain.Validations
{
    public class ViolacaoValidar
    {
        public LambdaExpression Propriedade { get; set; }
        public string Mensagem { get; set; }
    }
}
