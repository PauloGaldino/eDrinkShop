using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Contatos
{
    public class Endereco
    {
        public Endereco()
        {

        }
        [Display(Name ="Código")]
        public int EnderecoId { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Endereço")]
        public string Logradouro { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }


        public ICollection<EnderecoPessoa> EnderecosPessoas { get; set; }
        public ICollection<EnderecoCliente> EnderecoClientes { get; set; }

    }

}
