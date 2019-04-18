using Domain.Entities.Vendas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Data.EntityConfig.VendasConfiguratiosn
{
    public class DepartamentoConfig : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(d => d.DepartamentoId);

            builder
                .Property(d => d.Nome)
                .HasColumnType("vachar(50)")
                .IsRequired();
        }
    }
}
