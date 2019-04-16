using Domain.Entities.Contatos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Data.EntityConfig.ContatoEntityConfig
{
    public class EnderecoClienteConfiguration : IEntityTypeConfiguration<EnderecoCliente>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EnderecoCliente> builder)
        {

        }
    }
}
