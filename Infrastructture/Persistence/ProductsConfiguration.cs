using Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructture.Persistence
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(builder => builder.ProductId);
            builder.Property(c => c.ProductId).
                HasConversion(productId => productId.Id,
                value => new ProductId(value)
                );
            builder.Property(c=>c.ProductId).HasMaxLength(50).IsRequired(true);
            builder.OwnsOne(p => p.Price, pricebuilder =>
            {
                pricebuilder.Property(m => m.currency).HasMaxLength(50);
            });
            builder.Property(c => c.ProductId).HasMaxLength(200).IsRequired(true);
            builder.Property(c => c.CategoryId).HasConversion(categoryId => categoryId.Id, value => new CategoryId(value));


            builder.HasOne<Category>().WithMany().HasForeignKey(x=>x.CategoryId);
        }
    }
}
