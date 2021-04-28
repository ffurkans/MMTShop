using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MMT.Domain.Categories;

namespace MMT.Infrastructure.EF.EntityConfigurations
{
    class CategoryConfiguration
     : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> categoryConfiguration)
        {
            categoryConfiguration.HasKey(a => a.Id);
            categoryConfiguration.Property(a => a.Name).HasMaxLength(100);
        }
    }
}
