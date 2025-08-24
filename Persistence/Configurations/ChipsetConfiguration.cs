using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ChipsetConfiguration: IEntityTypeConfiguration<Chipset>
{
    public void Configure(EntityTypeBuilder<Chipset> builder)
    {
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}