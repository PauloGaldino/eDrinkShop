using ECommerce.Models.CidadeModel;
using ECommerce.Models.DepartamentosModels;
using System.Data.Entity;


namespace ECommerce.Models
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(): base("DefaultConnection")
        {

        }

        public DbSet<Departamento> Departamentos { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.CidadeModel.Cidade> Cidades { get; set; }
    }
}