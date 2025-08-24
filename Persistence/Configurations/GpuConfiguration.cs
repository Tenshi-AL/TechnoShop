using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class GpuConfiguration: IEntityTypeConfiguration<GPU>
{
    public void Configure(EntityTypeBuilder<GPU> builder)
    {
        builder.Property(g => g.GPUModel)
            .HasMaxLength(100);

        builder.Property(g => g.Interface)
            .HasMaxLength(50);

        builder.Property(g => g.CoolingSystem)
            .HasMaxLength(50);

        builder.Property(g => g.HDMI_Version)
            .HasMaxLength(20);

        builder.Property(g => g.DisplayPort_Version)
            .HasMaxLength(20);

        builder.Property(g => g.Dimensions_mm)
            .HasMaxLength(50);

        builder.Property(g => g.ExtraPower)
            .HasMaxLength(50);
    }
}