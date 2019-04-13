using APPLICATION.CORE.Interfaces;
using Ardalis.GuardClauses;
using System.Collections.Generic;

namespace APPLICATION.CORE.Entities.ComprasAgregadas
{
    public class Compra : BaseEntity, IAggregateRoot
    {
        public string IdentityGuid { get; private set; }

        private List<MetodoPagamento> _metodosPagamentos = new List<MetodoPagamento>();

        public IEnumerable<MetodoPagamento> MetodosPagamentos => _metodosPagamentos.AsReadOnly();

        private Compra()
        {
            // required by EF
        }

        public Compra(string identity) : this()
        {
            Guard.Against.NullOrEmpty(identity, nameof(identity));
            IdentityGuid = identity;
        }
    }
}

