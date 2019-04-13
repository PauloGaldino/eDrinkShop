using System;

namespace Domain.Entities.Pessoas
{
    public class Fisica
    {
        public Fisica()
        {

        }

        //Chave estrangeria

        public int PessoaId { get; set; }

        //Propriedade de navegação
        public Pessoa Pessoa { get; set; }

        public int FisicaId { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }

    }
}
