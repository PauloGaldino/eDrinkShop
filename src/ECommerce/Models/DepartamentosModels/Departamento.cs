using ECommerce.Models.CidadeModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models.DepartamentosModels
{
    public class Departamento
    {
        [Key]
        public int DepartmentoId { get; set; }

        [Required (ErrorMessage ="O preenchimento do campo {0}  É OBRIGATORIO")]

       [MaxLength (50, ErrorMessage ="O tamanho do campo {0} dever ser de no máximo {1} CARACTERES")]
       [Display(Name ="Departamento")]
        public string Nome { get; set; }

        public virtual ICollection<Cidade>  Cidades { get; set; }


       

    }
}