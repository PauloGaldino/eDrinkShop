using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Contatos
{
    public class Telefone
    {
        public Telefone()
        {

        }
        [Display(Name ="Código")]
        public int TelefoneId { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Display(Name = "Código")]
        public int TelefoneTipoId { get; set; }

        [Display(Name = "Telefone Tipo")]
        public TelefoneTipo TelefoneTipo { get; set; }

        public ICollection<Contato> Contato { get; set; }

    }
}
