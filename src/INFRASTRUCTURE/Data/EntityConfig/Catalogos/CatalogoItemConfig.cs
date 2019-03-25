using APPLICATION.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFRASTRUCTURE.Data.EntityConfig.Catalogos
{
    public class CatalogoItemConfig : IEntityTypeConfiguration<CatalogoItem>
    {
        public void Configure(EntityTypeBuilder<CatalogoItem> builder)
        {
            builder.Property(ci => ci.Id)
                .ForSqlServerUseSequenceHiLo("catalog_hilo")
                .IsRequired();

            builder.Property(ci => ci.Nome)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.Preco)
                .IsRequired(true);

            builder.Property(ci => ci.FotoUri)
                .IsRequired(false);

            builder.HasOne(ci => ci.CatalogoMarca)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogoMarcaId);

            builder.HasOne(ci => ci.CatalogoTipo)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogoTipoId);
        }
    }
}
