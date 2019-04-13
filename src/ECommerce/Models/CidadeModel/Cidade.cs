using ECommerce.Models.DepartamentosModels;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.CidadeModel
{
    public class Cidade
    {
        [Key]
        public int CidadeId { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo {0}  É OBRIGATORIO")]
        [MaxLength(50, ErrorMessage = "O tamanho do campo {0} dever ser de no máximo {1} CARACTERES")]
        [Display(Name ="Cidade")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo {0}  É OBRIGATORIO")]
        [Display(Name ="Id do Departamento")]
        public int DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; }

        public override int GetHashCode()
        {
            return CidadeId;
        }

    }
}