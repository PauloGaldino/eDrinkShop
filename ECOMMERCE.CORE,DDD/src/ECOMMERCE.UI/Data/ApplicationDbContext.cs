using Domain.Entities.Pessoas;
using ECOMMERCE.ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.UI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PessoaTipo> PessoaTipo { get; set; }
        public DbSet<Base> Base { get; set; }
    }
}
