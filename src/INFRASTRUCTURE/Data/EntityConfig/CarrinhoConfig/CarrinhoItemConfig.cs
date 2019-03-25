using APPLICATION.CORE.Entities.CarrinhoAgregado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFRASTRUCTURE.Data.EntityConfig.CarrinhoConfig
{
    public class CarrinhoItemConfig : IEntityTypeConfiguration<CarrinhoItem>
    {
        public void Configure(EntityTypeBuilder<CarrinhoItem> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ForSqlServerUseSequenceHiLo("catalog_hilo")
                .IsRequired();

            builder.Property(c => c.PrecoUnitario)
                .HasColumnType("decimal(18,2)")
                .IsRequired(true);

            builder.Property(c => c.PrecoUnitario)
                .IsRequired(true);

        }
    }
}
