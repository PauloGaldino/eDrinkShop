using System;

namespace APPLICATION.CORE.Exceptions
{
    public class CarrinhoNaoEncontradoException : Exception
    {
        public CarrinhoNaoEncontradoException(int carrinhoId) : base($"No basket found with id {carrinhoId}")
        {
        }

        protected CarrinhoNaoEncontradoException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public CarrinhoNaoEncontradoException(string message) : base(message)
        {
        }

        public CarrinhoNaoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
