using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence;

public class TechnoShopContext: IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public TechnoShopContext(DbContextOptions<TechnoShopContext> options) : base(options) => Database.EnsureCreated();
    public TechnoShopContext() => Database.EnsureCreated();
    
    public DbSet<Chipset> Chipsets { get; set; }
    public DbSet<GPU> Gpus { get; set; }
    public DbSet<GPUBrand> GpuBrands { get; set; }
    public DbSet<GpuManufacturer> GpuManufacturers { get; set; }
    public DbSet<MemoryType> MemoryTypes { get; set; }
    public DbSet<Motherboard> Motherboards { get; set; }
    public DbSet<MotherboardBrand> MotherboardBrands { get; set; }
    public DbSet<Processor> Processors { get; set; }
    public DbSet<ProcessorBrand> ProcessorBrands { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<PSU> Psus { get; set; }
    public DbSet<PSUBrand> PsuBrands { get; set; }
    public DbSet<PSUFormFactor> PsuFormFactors { get; set; }
    public DbSet<RAM> Rams { get; set; }
    public DbSet<RamBrand> RamBrands { get; set; }
    public DbSet<Socket> Sockets { get; set; }
    public DbSet<SSD> Ssds { get; set; }
    public DbSet<SSDBrand> SsdBrands { get; set; }
    public DbSet<SSDFormFactor> SsdFormFactors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ChipsetConfiguration());
        builder.ApplyConfiguration(new GpuConfiguration());
        builder.ApplyConfiguration(new MotherboardConfiguration());
        builder.ApplyConfiguration(new ProcessorConfiguration());
        builder.ApplyConfiguration(new PsuConfiguration());
        builder.ApplyConfiguration(new RamConfiguration());
        builder.ApplyConfiguration(new SsdConfiguration());
        builder.ApplyConfiguration(new RoleConfiguration());
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        //TODO remove this after seed
        //optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=shopDb;Username=admin;Password=root");
    }
}