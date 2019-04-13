using System;

namespace Domain.Entities.Pessoas
{
   public class Cliente
    {
        public Cliente()
        {
                
        }
        public int ClienteId { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        //ativo e com 5 anos de cadastro
        public bool ClienteEspecial(Cliente cliente)
        {
            return cliente.Ativo && DateTime.Now.Year - cliente.DataCadastro.Year >= 5;
        }

        //Chave estrangeria
        public int PessoaId { get; set; }

        //Propriedade de navegação
        public Pessoa Pessoa { get; set; }

    }

}
