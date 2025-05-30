﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("SaleItems");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.HasOne(u => u.Product).WithMany().HasForeignKey(u => u.ProductId).IsRequired();
        builder.HasOne(u => u.Sale).WithMany(s => s.SaleItems).HasForeignKey(u => u.SaleId).IsRequired();

        builder.Property(u => u.Quantity).IsRequired();
        builder.Property(u => u.UnitPrice).IsRequired();
        builder.Property(u => u.Discount).IsRequired();
        builder.Property(u => u.Total).IsRequired();
    }
}
