using System.ComponentModel.DataAnnotations;

namespace ECOMMERCE.ApplicationCore.Entities
{
   public class Base
    {
        [Display(Name ="Código")]
        public int Id { get; set; }
    }
}
