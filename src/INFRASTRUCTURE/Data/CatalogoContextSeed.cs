using APPLICATION.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Data
{
    public class CatalogoContextSeed : DbContext
    {

        public static async Task SeedAsync(CatalogoContext catalogoContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                if (!catalogoContext.CatalogoMarcas.Any())
                {
                    catalogoContext.CatalogoMarcas.AddRange(
                        GetPreconfiguredCatalogoMarcas());

                    await catalogoContext.SaveChangesAsync();
                }

                if (!catalogoContext.CatalogosTipos.Any())
                {
                    catalogoContext.CatalogosTipos.AddRange(
                        GetPreconfiguredCatalogosTipos());

                    await catalogoContext.SaveChangesAsync();
                }

                if (!catalogoContext.CatalogoItems.Any())
                {
                    catalogoContext.CatalogoItems.AddRange(
                        GetPreconfiguredItems());

                    await catalogoContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<CatalogoContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(catalogoContext, loggerFactory, retryForAvailability);
                }
            }
        }

        static IEnumerable<CatalogoMarca> GetPreconfiguredCatalogoMarcas()
        {
            return new List<CatalogoMarca>()
            {
                new CatalogoMarca() { Marca = "KaskolaKIdelicia"},
                new CatalogoMarca () { Marca = "Sodaskidelicia" },
                new CatalogoMarca() { Marca = "GuaraDelicia" },
                new CatalogoMarca() { Marca = "ItuDelicia" },
                new CatalogoMarca() { Marca = "XDelicia" }
            };
        }

        static IEnumerable<CatalogoTipo> GetPreconfiguredCatalogosTipos()
        {
            return new List<CatalogoTipo>()
            {
                new CatalogoTipo() { Tipo = "Litro vidro"},
                new CatalogoTipo() { Tipo = "Litro plastico"},
                new CatalogoTipo() { Tipo = "Garrafa 400 ml" },
                new CatalogoTipo() { Tipo = "Garrafa 250 ml" },
                new CatalogoTipo() { Tipo = "PET "},
                new CatalogoTipo() { Tipo = "PET 250 ml" }
            };
        }

        static IEnumerable<CatalogoItem> GetPreconfiguredItems()
        {
            return new List<CatalogoItem>()
            {
                new CatalogoItem() { CatalogoTipoId=2,CatalogoMarcaId=2, DescricaoCurta = ".NET Bot Black Sweatshirt", Nome = ".NET Bot Black Sweatshirt", Preco = 19.5M, FotoUri = "http://catalogbaseurltobereplaced/images/products/1.png" },
                new CatalogoItem() { CatalogoTipoId=1,CatalogoMarcaId=2, DescricaoCurta = ".NET Black & White Mug", Nome = ".NET Black & White Mug", Preco= 8.50M, FotoUri = "http://catalogbaseurltobereplaced/images/products/2.png" },
                new CatalogoItem() { CatalogoTipoId=2,CatalogoMarcaId=5, DescricaoCurta = "Prism White T-Shirt", Nome = "Prism White T-Shirt", Preco = 12, FotoUri = "http://catalogbaseurltobereplaced/images/products/3.png" },
                new CatalogoItem() { CatalogoTipoId=2,CatalogoMarcaId=2, DescricaoCurta = ".NET Foundation Sweatshirt", Nome = ".NET Foundation Sweatshirt", Preco = 12, FotoUri = "http://catalogbaseurltobereplaced/images/products/4.png" },
                new CatalogoItem() { CatalogoTipoId=3,CatalogoMarcaId=5, DescricaoCurta = "Roslyn Red Sheet", Nome = "Roslyn Red Sheet", Preco = 8.5M, FotoUri = "http://catalogbaseurltobereplaced/images/products/5.png" },
                new CatalogoItem() { CatalogoTipoId=2,CatalogoMarcaId=2, DescricaoCurta = ".NET Blue Sweatshirt", Nome = ".NET Blue Sweatshirt", Preco = 12, FotoUri = "http://catalogbaseurltobereplaced/images/products/6.png" },
                new CatalogoItem() { CatalogoTipoId=2,CatalogoMarcaId=5, DescricaoCurta = "Roslyn Red T-Shirt", Nome = "Roslyn Red T-Shirt", Preco = 12, FotoUri = "http://catalogbaseurltobereplaced/images/products/7.png"  },
                new CatalogoItem() { CatalogoTipoId=2,CatalogoMarcaId=5, DescricaoCurta = "Kudu Purple Sweatshirt", Nome = "Kudu Purple Sweatshirt", Preco = 8.5M, FotoUri = "http://catalogbaseurltobereplaced/images/products/8.png" },
                new CatalogoItem() { CatalogoTipoId=1,CatalogoMarcaId=5, DescricaoCurta = "Cup<T> White Mug", Nome = "Cup<T> White Mug", Preco = 12, FotoUri = "http://catalogbaseurltobereplaced/images/products/9.png" },
                new CatalogoItem() { CatalogoTipoId=3,CatalogoMarcaId=2, DescricaoCurta = ".NET Foundation Sheet", Nome = ".NET Foundation Sheet", Preco = 12, FotoUri = "http://catalogbaseurltobereplaced/images/products/10.png" },
                new CatalogoItem() { CatalogoTipoId=3,CatalogoMarcaId=2, DescricaoCurta = "Cup<T> Sheet", Nome = "Cup<T> Sheet", Preco = 8.5M, FotoUri = "http://catalogbaseurltobereplaced/images/products/11.png" },
                new CatalogoItem() { CatalogoTipoId=2,CatalogoMarcaId=5, DescricaoCurta = "Prism White TShirt", Nome = "Prism White TShirt", Preco = 12, FotoUri = "http://catalogbaseurltobereplaced/images/products/12.png" }
            };
        }
    }
}
