using Domain.Entities.Pessoas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Data.EntityConfig.PessoasEntityConfig
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.ClienteId);

            builder
                .HasOne(c => c.Pessoa)
                .WithMany(c => c.Clientes)
                .HasForeignKey(c => c.PessoaId)
                .HasPrincipalKey(c => c.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.DataCadastro)
               .IsRequired();

            builder.Property(e => e.Ativo)
               .IsRequired();
        }
    }
}
