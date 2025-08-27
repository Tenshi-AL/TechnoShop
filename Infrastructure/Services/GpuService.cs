using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Services;

public class GpuService(TechnoShopContext db): IGpuService
{
    public async Task<IEnumerable<GPU>> List(CancellationToken cancellationToken = default) =>
        await db.Gpus
            .AsNoTracking()
            .Include(p => p.Manufacturer)
            .Include(p => p.MemoryType)
            .Include(p => p.Brand)
            //.Filter(gpuListOptions)
            //.Order(gpuListOptions)
            //.Pagination(gpuListOptions)
            .ToListAsync(cancellationToken);

    public async Task<GPU?> Get(Guid id, CancellationToken cancellationToken = default) =>
        await db.Gpus
            .AsNoTracking()
            .Include(p => p.Manufacturer)
            .Include(p => p.MemoryType)
            .Include(p => p.Brand)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);

    public async Task<GPU> Create(GPU gpu, CancellationToken cancellationToken = default)
    {
        db.Gpus.Add(gpu);
        await db.SaveChangesAsync(cancellationToken);
        return gpu;
    }
    
    public async Task<Guid> Update(GPU gpu, CancellationToken cancellationToken = default)
    {
        db.Gpus.Update(gpu);
        await db.SaveChangesAsync(cancellationToken);
        return gpu.Id;
    }
}