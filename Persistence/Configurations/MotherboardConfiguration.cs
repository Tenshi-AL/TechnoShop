using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class MotherboardConfiguration: IEntityTypeConfiguration<Motherboard>
{
    public void Configure(EntityTypeBuilder<Motherboard> builder)
    {
        builder.Property(m => m.ChipsetCooling).HasMaxLength(50);
        builder.Property(m => m.VRMCooling).HasMaxLength(50);
        builder.Property(m => m.DIMMSlots).HasMaxLength(50);
        builder.Property(m => m.PCIe_x16).HasMaxLength(50);
        builder.Property(m => m.MotherboardPower).HasMaxLength(50);
        builder.Property(m => m.CPU_Power).HasMaxLength(50);

        builder.Property(m => m.M2Type).HasMaxLength(50);
        builder.Property(m => m.AudioCodec).HasMaxLength(50);
        builder.Property(m => m.Ethernet).HasMaxLength(50);
        builder.Property(m => m.VideoOutputs).HasMaxLength(50);

        builder.Property(m => m.OnboardUSB3_2Gen2).HasMaxLength(50);
        builder.Property(m => m.OnboardUSB3_2Gen1).HasMaxLength(50);
        builder.Property(m => m.OnboardUSB2_0).HasMaxLength(50);

        builder.Property(m => m.FormFactor).HasMaxLength(50);
        builder.Property(m => m.RAIDSupport).HasMaxLength(50);
        builder.Property(m => m.WiFiAdapter).HasMaxLength(50);
        builder.Property(m => m.BluetoothAdapter).HasMaxLength(50);
        builder.Property(m => m.Misc).HasMaxLength(100);
        builder.Property(m => m.BrandURL).HasMaxLength(200);
    }
}