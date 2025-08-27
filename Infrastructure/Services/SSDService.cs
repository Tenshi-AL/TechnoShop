using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Services;

public class SSDService(TechnoShopContext db) : ISSDService
{
    public async Task<ICollection<SSD>> List(CancellationToken cancellationToken = default) =>
        await db.Ssds
            .AsNoTracking()
            .Include(p => p.Brand)
            .Include(p => p.FormFactor)
            //.Filter(parameters)
            //.Order(parameters)
            //.Pagination(parameters)
            .ToListAsync(cancellationToken);

    public async Task<SSD?> Get(Guid id, CancellationToken cancellationToken = default) =>
        await db.Ssds
            .AsNoTracking()
            .Include(p => p.Brand)
            .Include(p => p.FormFactor)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);

    public async Task<SSD> Create(SSD ssd, CancellationToken cancellationToken = default)
    {
        db.Ssds.Add(ssd);
        await db.SaveChangesAsync(cancellationToken);
        return ssd;
    }
    
    public async Task<Guid> Update(SSD ssd, CancellationToken cancellationToken = default)
    {
        db.Ssds.Update(ssd);
        await db.SaveChangesAsync(cancellationToken);
        return ssd.Id;
    }
}