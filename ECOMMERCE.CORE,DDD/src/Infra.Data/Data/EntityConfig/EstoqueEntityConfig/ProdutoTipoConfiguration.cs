using Domain.Entities.Estoques;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Data.EntityConfig.EstoqueEntityConfig
{
    public class ProdutoTipoConfiguration : IEntityTypeConfiguration<ProdutoTipo>
    {
        public void Configure(EntityTypeBuilder<ProdutoTipo> builder)
        {
            builder.HasKey(pr => pr.ProdutoTipoId);

            builder
                .HasOne(pr => pr.Produto)
                .WithOne(pr => pr.ProdutoTipo)
                .HasForeignKey<Produto>(pr => pr.ProdutoTipoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(pr => pr.Descricao)
                .HasColumnType("varchar(50)")
                .IsRequired();

        }
    }
}
