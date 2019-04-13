using Domain.Entities.Pessoas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Data.EntityConfig.PessoasEntityConfig
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(p => p.PessoaId);

           
            builder.Property(p => p.Nome)
                .HasColumnType("varchar (100)")
                .IsRequired();

            builder.Property(p => p.Sobrenome)
                .HasColumnType("varchar(50)")
                .IsRequired();

        }
    }
}
 