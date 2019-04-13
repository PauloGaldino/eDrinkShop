using Domain.Entities.Contatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infra.Data.Data.EntityConfig.ContatoEntityConfig
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(t => t.TelefoneId);

            builder.Property(t => t.Numero)
                .HasColumnType("varchar(30)")
                .IsRequired();
        }
    }
}
