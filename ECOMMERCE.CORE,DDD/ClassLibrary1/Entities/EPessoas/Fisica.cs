using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.EPessoas
{
    public class Fisica : Base
    {
        [Display(Name = "Código")]
        public int FisicaId { get; set; }

        [Display(Name ="CPF")]
        public string Cpf { get; set; }

        [Display(Name ="RG")]
        public string Rg { get; set; }
    }
}
