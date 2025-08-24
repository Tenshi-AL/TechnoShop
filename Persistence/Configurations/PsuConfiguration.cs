using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PsuConfiguration: IEntityTypeConfiguration<PSU>
{
    public void Configure(EntityTypeBuilder<PSU> builder)
    {
        builder.Property(p => p.TotalPower_W)
                   .IsRequired();

            builder.Property(p => p.Power_3_3_5V_W)
                   .IsRequired();

            builder.Property(p => p.Power_12V_W)
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.Property(p => p.Current_5V_A)
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.Property(p => p.Current_3_3V_A)
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.Property(p => p.Current_12V1_A)
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.Property(p => p.Current_minus12V_A)
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.Property(p => p.Current_5Vsb_A)
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.Property(p => p.MotherboardConnector)
                   .HasMaxLength(50);

            builder.Property(p => p.CPUConnector)
                   .HasMaxLength(50);

            builder.Property(p => p.MolexCount)
                   .IsRequired();

            builder.Property(p => p.SATA_Count)
                   .IsRequired();

            builder.Property(p => p.GPUConnector)
                   .HasMaxLength(50);

            builder.Property(p => p.InputVoltageRange_V)
                   .HasMaxLength(50);

            builder.Property(p => p.EfficiencyStandard)
                   .HasMaxLength(20);

            builder.Property(p => p.EfficiencyPercent)
                   .HasPrecision(5, 2);

            builder.Property(p => p.ATXStandard)
                   .HasMaxLength(20);

            builder.Property(p => p.Dimensions_mm)
                   .HasMaxLength(50);

            builder.Property(p => p.Fan_mm)
                   .IsRequired();

            builder.Property(p => p.Notes)
                   .HasMaxLength(200);

            builder.Property(p => p.BrandURL)
                   .HasMaxLength(200);
    }
}