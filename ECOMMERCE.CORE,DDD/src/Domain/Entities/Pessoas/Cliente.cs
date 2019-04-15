using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Pessoas
{
   public class Cliente
    {
        public Cliente()
        {
                
        }
        //Chave estrangeria
        [Display(Name = "Codigo da Pessoa")]
        public int PessoaId { get; set; }

        //Propriedade de navegação
        public Pessoa Pessoa { get; set; }
        [Display(Name = "Codigo do CLiente")]
        public int ClienteId { get; set; }

        [Display(Name = "Data do Cadastro")]
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        //ativo e com 5 anos de cadastro
        public bool ClienteEspecial(Cliente cliente)
        {
            return cliente.Ativo && DateTime.Now.Year - cliente.DataCadastro.Year >= 5;
        }

      

    }

}
