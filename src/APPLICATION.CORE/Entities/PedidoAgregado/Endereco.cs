using System;

namespace APPLICATION.CORE.Entities.PedidoAgregado
{
   public class Endereco// ValueObject
    {
        public String Logradouro { get; private set; }

        public String Cidade { get; private set; }

        public String Estado { get; private set; }

        public String Pais { get; private set; }

        public String CEP { get; private set; }

        private Endereco() { }

        public Endereco(string logradouro, string cidade, string estado, string pais, string cep)
        {
            Logradouro = logradouro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            CEP = cep;
        }
    }
}
