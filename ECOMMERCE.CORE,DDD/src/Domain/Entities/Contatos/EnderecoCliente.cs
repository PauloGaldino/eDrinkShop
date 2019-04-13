

using Domain.Entities.Pessoas;

namespace Domain.Entities.Contatos
{
    public class EnderecoCliente
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public int EnderecoId { get; set; }

        public Cliente Cliente { get; set; }
        public Endereco Endereco { get; set; }
    }
}
