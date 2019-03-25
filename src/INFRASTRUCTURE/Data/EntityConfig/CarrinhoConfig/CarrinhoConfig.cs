using APPLICATION.CORE.Entities.CarrinhoAgregado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFRASTRUCTURE.Data.EntityConfig.CarrinhoConfig
{
    public class CarrinhoConfig : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Carrinho.Items));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
