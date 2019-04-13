using System.Collections.Generic;

namespace Domain.Entities.Contatos
{
    public class Telefone
    {
        public Telefone()
        {

        }
        public int TelefoneId { get; set; }
        public string Numero { get; set; }

        public int TelefoneTipoId { get; set; }
        public TelefoneTipo TelefoneTipo { get; set; }

        public ICollection<Contato> Contato { get; set; }

    }
}
