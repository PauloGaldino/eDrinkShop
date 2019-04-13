using Domain.Entities.Estoques;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Data.EntityConfig.EstoqueEntityConfig
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.ProdutoId);

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Lote)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.DataFabricacao)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .IsRequired();

            builder.Property(p => p.DataValidade)
               .HasColumnType("datetime")
               .HasDefaultValueSql("(getdate())")
               .IsRequired();
        }
    }
}
