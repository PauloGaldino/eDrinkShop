using Domain.Entities.Contatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Data.EntityConfig.ContatoEntityConfig
{
    class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {

            builder
                .HasOne(c=> c.Telefone)
                .WithMany(c => c.Contato)
                .HasForeignKey(ep => ep.TelefoneId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Email)
                .WithMany(c => c.Contatos)
                .HasForeignKey(c =>c.EmailId)
                 .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
