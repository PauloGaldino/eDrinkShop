using Domain.Entities.Pessoas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Data.EntityConfig.PessoasEntityConfig
{
    public class FisicaConfiguration : IEntityTypeConfiguration<Fisica>
    {
        public void Configure(EntityTypeBuilder<Fisica> builder)
        {
            builder.HasKey(f => f.FisicaId);

            builder.Property(f => f.Cpf)
                .HasColumnType("varchar(15)")
                .IsUnicode()
                .IsRequired();

            builder.Property(f => f.Rg)
                .HasColumnType("varchar (15)")
                .IsRequired();

            builder.Property(f => f.DataNascimento)
             
                .IsRequired();
        }
    }
}
