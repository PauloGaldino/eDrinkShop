using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Base
    {
        [Display(Name ="Código")]
        public int Id { get; set; }
    }
}
