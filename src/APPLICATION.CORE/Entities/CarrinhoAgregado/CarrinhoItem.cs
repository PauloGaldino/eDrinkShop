using System;
using System.Collections.Generic;
using System.Text;

namespace APPLICATION.CORE.Entities.CarrinhoAgregado
{
    public class CarrinhoItem : BaseEntity
    {
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public int CatalogoItemId { get; set; }
    }
}
