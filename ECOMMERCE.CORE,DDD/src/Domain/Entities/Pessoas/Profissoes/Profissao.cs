using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Pessoas.Profissoes
{
    public class Profissao
    {
        public Profissao()
        {

        }
        [Display(Name =("Código da Profissão"))]
        public int ProfissaoId { get; set; }

        [Display(Name = ("Nome"))]
        public string Nome { get; set; }

        [Display(Name = ("Descrição"))]
        public string Descricao { get; set; }

       [Display(Name = ("CBO"))]
        public string CBO { get; set; }

        public ICollection<ProfissaoPessoa> ProfissaoPessoa { get; set; }
    }
}
