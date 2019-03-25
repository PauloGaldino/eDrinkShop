using APPLICATION.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace INFRASTRUCTURE.Data.EntityConfig.Catalogos
{
    public class CatalogoTipoConfig : IEntityTypeConfiguration<CatalogoTipo>
    {
        public void Configure(EntityTypeBuilder<CatalogoTipo> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("catalogo_tipo_hilo")
               .IsRequired();

            builder.Property(cb => cb.Tipo)
                .HasColumnType("varchar(100)")
                .IsRequired();
               
        }
    }
}
