using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class RamConfiguration: IEntityTypeConfiguration<RAM>
{
    public void Configure(EntityTypeBuilder<RAM> builder)
    {
        builder.Property(r => r.CapacityGB)
            .IsRequired();

        builder.Property(r => r.ModuleCount)
            .IsRequired();

        builder.Property(r => r.FrequencyMHz)
            .IsRequired();

        builder.Property(r => r.Timings)
            .HasMaxLength(20);

        builder.Property(r => r.Voltage_V)
            .HasPrecision(4, 2)
            .IsRequired();

        builder.Property(r => r.Heatsinks)
            .IsRequired();

        builder.Property(r => r.XMP)
            .HasMaxLength(20);

        builder.Property(r => r.Rank)
            .HasMaxLength(10);

        builder.Property(r => r.ECC)
            .HasMaxLength(20);

        builder.Property(r => r.Buffered)
            .HasMaxLength(20);

        builder.Property(r => r.Color)
            .HasMaxLength(30);

        builder.Property(r => r.BrandURL)
            .HasMaxLength(200);
    }
}