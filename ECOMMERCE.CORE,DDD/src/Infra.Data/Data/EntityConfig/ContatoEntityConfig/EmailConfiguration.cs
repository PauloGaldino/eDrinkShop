using Domain.Entities.Contatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Data.EntityConfig.ContatoEntityConfig
{
    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(em => em.EmailId);


            builder
                .Property(em => em.EnderecoEmail)
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}
