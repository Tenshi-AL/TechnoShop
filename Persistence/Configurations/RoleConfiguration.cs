using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class RoleConfiguration: IEntityTypeConfiguration<IdentityRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
    {
        builder.HasData(new IdentityRole<Guid>
        {
            Id = Guid.Parse("2c5e174e-3b0e-446f-86af-483d56fd7210"), 
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR".ToUpper()
        });
        builder.HasData(new IdentityRole<Guid>
        {
            Id = Guid.Parse("3c5e174e-3b0e-446f-86af-483d56fd7210"), 
            Name = "Client",
            NormalizedName = "CLIENT".ToUpper()
        });
    }
}