using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.SaleNumber).IsRequired().ValueGeneratedOnAdd();
        builder.Property(u => u.TotalAmount).IsRequired();
        builder.Property(u => u.IsCancelled).IsRequired();
        builder.Property(u => u.SaleDate).HasColumnType("timestamptz").IsRequired();

        builder.HasOne(u => u.Branch)
            .WithMany()
            .HasForeignKey(u => u.BranchId)
            .IsRequired();

        builder.HasOne(u => u.User)
            .WithMany()
            .HasForeignKey(u => u.UserId)
            .IsRequired();

        builder.HasMany(s => s.SaleItems)
            .WithOne(i => i.Sale)
            .HasForeignKey(i => i.SaleId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
