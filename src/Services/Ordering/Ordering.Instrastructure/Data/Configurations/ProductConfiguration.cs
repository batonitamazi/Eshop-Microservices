﻿
namespace Ordering.Instrastructure.Data.Configurations
{
    internal class ProductConfiguration :  IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id).HasConversion(
                productId => productId.Value,
                dbId => ProductId.Of(dbId));

            builder.Property(k => k.Name).HasMaxLength(100).IsRequired();
        }
    }
}
