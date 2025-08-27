using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Services;

public class RAMService(TechnoShopContext db) : IRAMService
{
    public async Task<ICollection<RAM>> List(CancellationToken cancellationToken = default) =>
        await db.Rams
            .AsNoTracking()
            .Include(p => p.Brand)
            .Include(p => p.MemoryType)
            //.Filter(parameters)
            //.Order(parameters)
            //.Pagination(parameters)
            .ToListAsync(cancellationToken);

    public async Task<RAM?> Get(Guid id, CancellationToken cancellationToken = default) =>
        await db.Rams
            .AsNoTracking()
            .Include(p => p.Brand)
            .Include(p => p.MemoryType)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);

    public async Task<RAM> Create(RAM ram, CancellationToken cancellationToken = default)
    {
        db.Rams.Add(ram);
        await db.SaveChangesAsync(cancellationToken);
        return ram;
    }
    
    public async Task<Guid> Update(RAM ram, CancellationToken cancellationToken = default)
    {
        db.Rams.Update(ram);
        await db.SaveChangesAsync(cancellationToken);
        return ram.Id;
    }
}