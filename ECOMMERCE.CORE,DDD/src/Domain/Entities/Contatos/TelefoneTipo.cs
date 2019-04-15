using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Contatos
{
    public class TelefoneTipo
    {
        public TelefoneTipo()
        {

        }
        [Display(Name ="Codigo")]
        public int TelefoneTipoId { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public Telefone Telefone { get; set; }

    }
}
