using System;
using System.Collections.Generic;
using System.Linq;

namespace eDrinkShop.Web.ViewModels
{
    public class CarrinhoViewModel
    {
        public int Id { get; set; }
        public List<CarrinhoItemViewModel> Items { get; set; } = new List<CarrinhoItemViewModel>();
        public string CompraId { get; set; }

        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.PrecoUnitario * x.Quantidade), 2);
        }
    }
}
