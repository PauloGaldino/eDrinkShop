using Domain.Entities.Profissoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Data.EntityConfig.ProfissoesEntityConfig

{
    public class ProfissaoPessoaConfiguration : IEntityTypeConfiguration<ProfissaoPessoa>
    {
        public void Configure(EntityTypeBuilder<ProfissaoPessoa> builder)
        {
            builder.HasAlternateKey(pp => pp.Id);

            builder
                .HasOne(pp => pp.Pessoa)
                .WithMany(pp => pp.ProfissaoPessoa)
                .HasForeignKey(pp => pp.PessoaId)
                .HasPrincipalKey(pp => pp.PessoaId);

            builder
                .HasOne(pp => pp.Profissao)
                 .WithMany(pp => pp.ProfissaoPessoa)
                 .HasForeignKey(pp => pp.ProfissaoId)
                 .HasPrincipalKey(pp => pp.ProfissaoId);
        }
    }
}
