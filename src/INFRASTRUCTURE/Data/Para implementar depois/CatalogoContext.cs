

using APPLICATION.CORE.Entities;
using APPLICATION.CORE.Entities.CarrinhoAgregado;
using APPLICATION.CORE.Entities.ComprasAgregadas;
using APPLICATION.CORE.Entities.PedidoAgregado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFRASTRUCTURE.Data
{
    public class CatalogoContext : DbContext
    {
        private object modelBuilder;

        public CatalogoContext(DbContextOptions<CatalogoContext> options): base(options) { }

        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<CarrinhoItem> CarrinhoItems { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CatalogoItem> CatalogoItems { get; set; }
        public DbSet<CatalogoMarca> CatalogoMarcas { get; set; }
        public DbSet<CatalogoTipo> CatalogosTipos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Carrinho>(ConfigureCarrinho);
            builder.Entity<CatalogoMarca>(ConfigureCatalogoMarca);
            builder.Entity<CatalogoTipo>(ConfigureCatalogoTipo);
            builder.Entity<CatalogoItem>(ConfigureCatalogoItem);
            builder.Entity<Pedido>(ConfigurePedido);
            builder.Entity<PedidoItem>(ConfigurePedidoItem);
        }

        private void ConfigureCarrinho(EntityTypeBuilder<Carrinho> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Carrinho.Items));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureCatalogoItem(EntityTypeBuilder<CatalogoItem> builder)
        {
            builder.ToTable("Catalogo");

            builder.Property(ci => ci.Id)
                .ForSqlServerUseSequenceHiLo("catalogo_hilo")
                .IsRequired();

            builder.Property(ci => ci.Nome)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.Preco)
                .IsRequired(true);

            builder.Property(ci => ci.FotoUri)
                .IsRequired(false);

            builder.HasOne(ci => ci.CatalogoMarca)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogoMarcaId);

            builder.HasOne(ci => ci.CatalogoTipo)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogoTipoId);
        }

        private void ConfigureCatalogoMarca(EntityTypeBuilder<CatalogoMarca> builder)
        {
            builder.ToTable("CatalogoMarca");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("catalogo_brando_hilo")
               .IsRequired();

            builder.Property(cb => cb.Marca)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureCatalogoTipo(EntityTypeBuilder<CatalogoTipo> builder)
        {
            builder.ToTable("CatalogTipo");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("catalogo_tipo_hilo")
               .IsRequired();

            builder.Property(cb => cb.Tipo)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigurePedido(EntityTypeBuilder<Pedido> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Pedido.PedidoItems));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.OwnsOne(o => o.ShipToEndereco);
        }

        private void ConfigurePedidoItem(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.OwnsOne(i => i.ItemPedido);
        }
    }
}
