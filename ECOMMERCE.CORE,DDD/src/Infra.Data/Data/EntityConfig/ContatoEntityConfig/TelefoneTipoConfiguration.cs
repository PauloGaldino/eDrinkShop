using Domain.Entities.Contatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Data.EntityConfig.ContatoEntityConfig
{
    public class TelefoneTipoConfiguration : IEntityTypeConfiguration<TelefoneTipo>
    {
        public void Configure(EntityTypeBuilder<TelefoneTipo> builder)
        {
            builder.HasKey(tt => tt.TelefoneTipoId);

            builder.HasOne(tt => tt.Telefone)
                .WithOne(tt => tt.TelefoneTipo)
                .HasForeignKey<Telefone>(tt => tt.TelefoneTipoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(tt => tt.Descricao)
                .HasColumnType("varchar(30)")
                .IsRequired();
        }
    }
}
