using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class SsdConfiguration: IEntityTypeConfiguration<SSD>
{
    public void Configure(EntityTypeBuilder<SSD> builder)
    {
        builder.Property(s => s.Series)
            .HasMaxLength(50);

        builder.Property(s => s.CapacityGB)
            .IsRequired();

        builder.Property(s => s.Interface)
            .HasMaxLength(50);

        builder.Property(s => s.NANDType)
            .HasMaxLength(50);

        builder.Property(s => s.TRIMSupport)
            .IsRequired();

        builder.Property(s => s.Dimensions_mm)
            .HasMaxLength(20);

        builder.Property(s => s.Weight_g)
            .IsRequired();

        builder.Property(s => s.MaxReadMBs)
            .IsRequired();

        builder.Property(s => s.MaxWriteMBs)
            .IsRequired();

        builder.Property(s => s.TBW)
            .IsRequired();

        builder.Property(s => s.MTBF_MillionHours)
            .HasPrecision(6, 2)
            .IsRequired();

        builder.Property(s => s.BrandURL)
            .HasMaxLength(200);
    }
}