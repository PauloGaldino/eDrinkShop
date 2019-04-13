using System.ComponentModel.DataAnnotations;

namespace APPLICATION.CORE.Entities
{
    public class Produto : BaseEntity
    {
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
    }
}
