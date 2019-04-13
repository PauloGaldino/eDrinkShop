using Domain.Entities.Contatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Data.EntityConfig.ContatoEntityConfig
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.EnderecoId);

            builder.Property(e => e.Descricao)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(e => e.Logradouro)
                .HasColumnType("varchar (200)")
                .IsRequired();

            builder.Property(e => e.Complemento)
                .HasColumnType("varchar (100)");

            builder.Property(e => e.CEP)
                .HasColumnType("varchar (15)")
                .IsRequired();

            builder.Property(e => e.Bairro)
                .HasColumnType("varchar (200)")
                .IsRequired();


            builder.Property(e => e.Cidade)
                .HasColumnType("varchar (200)")
                .IsRequired();


            builder.Property(e => e.Estado)
                .HasColumnType("char (2)")
                .IsRequired();

        }
    }
}
