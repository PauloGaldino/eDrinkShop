using APPLICATION.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFRASTRUCTURE.Data.EntityConfig.Catalogos
{
    public class CatalogoMarcaConfig : IEntityTypeConfiguration<CatalogoMarca>
    {
        public void Configure(EntityTypeBuilder<CatalogoMarca> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("catalogo_marca_hilo")
               .IsRequired();

            builder.Property(cb => cb.Marca)
                .HasColumnType("varchar(100)")
                .IsRequired();
                
        }
    }
}
