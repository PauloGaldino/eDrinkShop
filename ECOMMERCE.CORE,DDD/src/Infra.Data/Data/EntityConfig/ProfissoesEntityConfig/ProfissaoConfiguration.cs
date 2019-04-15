using Domain.Entities.Pessoas.Profissoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Data.EntityConfig.ProfissoesEntityConfig
{
    public class ProfissaoConfiguration : IEntityTypeConfiguration<Profissao>
    {
        public void Configure(EntityTypeBuilder<Profissao> builder)
        {
            builder.HasKey(p => p.ProfissaoId);

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(p => p.CBO)
                .HasColumnType("varchar(300)")
                .IsRequired();
        }
    }
}
