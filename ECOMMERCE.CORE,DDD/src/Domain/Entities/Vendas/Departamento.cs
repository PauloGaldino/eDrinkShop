using Domain.Entities.Contatos;
using Domain.Validations;
using System.Collections.Generic;

namespace Domain.Entities.Vendas
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string Nome { get; set; }

        public Departamento()
        {

        }
        public Departamento(int DepartamentoId, string Nome)
        {
            this.DepartamentoId = DepartamentoId;
            this.Nome = Nome;


        }

    }
}

