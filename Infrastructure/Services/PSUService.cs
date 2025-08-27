using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Services;

public class PSUService(TechnoShopContext db) : IPSUService
{
    public async Task<ICollection<PSU>> List(CancellationToken cancellationToken = default) =>
        await db.Psus
            .AsNoTracking()
            .Include(p => p.Brand)
            .Include(p => p.FormFactor)
            //.Filter(parameters)
            //.Order(parameters)
            //.Pagination(parameters)
            .ToListAsync(cancellationToken);

    public async Task<PSU?> Get(Guid id, CancellationToken cancellationToken = default) =>
        await db.Psus
            .AsNoTracking()
            .Include(p => p.Brand)
            .Include(p => p.FormFactor)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);

    public async Task<PSU> Create(PSU psu, CancellationToken cancellationToken = default)
    {
        db.Psus.Add(psu);
        await db.SaveChangesAsync(cancellationToken);
        return psu;
    }
    
    public async Task<Guid> Update(PSU psu, CancellationToken cancellationToken = default)
    {
        db.Psus.Update(psu);
        await db.SaveChangesAsync(cancellationToken);
        return psu.Id;
    }
}