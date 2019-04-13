using APPLICATION.CORE.Entities;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Data.Context
{
    public class GeneralContext : DbContext
    {
        public GeneralContext(DbContextOptions<GeneralContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Produto> Produto { set; get; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se não estiver configurado no projeto IU pega deginição de chame do json configurado
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConectionConfig());

            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConectionConfig()
        {
            string strCon = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DDD2019;Integrated Security=False;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            return strCon;
        }

    }
}
