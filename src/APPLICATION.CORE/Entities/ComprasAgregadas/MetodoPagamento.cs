namespace APPLICATION.CORE.Entities.ComprasAgregadas
{
    public class MetodoPagamento :BaseEntity
    {

        public string Alias { get; set; }
        public string CartaoId { get; set; } // actual card data must be stored in a PCI compliant system, like Stripe
        public string Ultimo4 { get; set; }
    }
}
