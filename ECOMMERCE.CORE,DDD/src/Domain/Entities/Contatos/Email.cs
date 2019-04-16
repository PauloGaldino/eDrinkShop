using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Contatos
{
    public class Email
    {
        public Email()
        {

        }
        [Display(Name ="Código")]
        public int EmailId { get; set; }

        [Display(Name = "E-mail")]
        public string EnderecoEmail { get; set; }

      
        public ICollection<Contato> Contatos { get; set; }
    }
}
