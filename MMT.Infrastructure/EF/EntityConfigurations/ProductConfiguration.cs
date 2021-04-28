using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMT.Domain.Products;

namespace MMT.Infrastructure.EF.EntityConfigurations
{
    class ProductConfiguration
     : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> productConfiguration)
        {
            productConfiguration.HasKey(a => a.Id);
            productConfiguration.Property(a => a.Name).HasMaxLength(100);
            productConfiguration.Property(a => a.Description).HasMaxLength(500);
            productConfiguration.HasIndex(a => a.SKU);
            productConfiguration.HasIndex(a => a.Name);
            productConfiguration.Property(a => a.Price).HasColumnType("DECIMAL(19,4)");
        }
    }
}
