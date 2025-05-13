using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(p => p.Title).IsRequired();

        builder.Property(p => p.Price).IsRequired();

        builder.Property(p => p.Description);

        builder.Property(p => p.Category);

        builder.Property(p => p.Image);

        builder.OwnsOne(p => p.Rating, rating =>
        {
            rating.Property(r => r.Rate).HasColumnName("RatingRate");
            rating.Property(r => r.Count).HasColumnName("RatingCount");
        });

        builder.HasMany(p => p.ProductCategories)
               .WithOne(pc => pc.Product)
               .HasForeignKey(pc => pc.ProductId);
    }
}
