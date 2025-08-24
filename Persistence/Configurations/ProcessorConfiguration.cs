using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ProcessorConfiguration: IEntityTypeConfiguration<Processor>
{
    public void Configure(EntityTypeBuilder<Processor> builder)
    {
        builder.Property(p => p.PackageType).HasMaxLength(20);
        builder.Property(p => p.IncludedCooler).HasMaxLength(50);
    }
}