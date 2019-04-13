using Domain.Entities.Pessoas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Data.EntityConfig.PessoasEntityConfig
{
    public class PessoaTipoConfiguration : IEntityTypeConfiguration<PessoaTipo>
    {
        public void Configure(EntityTypeBuilder<PessoaTipo> builder)
        {
            builder.Property(pt => pt.Descricao)
                .HasColumnType("varchar (10)")
                .IsRequired();
        }
    }
}
