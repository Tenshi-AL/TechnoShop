using Domain.Models;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Services;

public class MotherboardService(TechnoShopContext db) : IMotherboardService
{
    public async Task<ICollection<Motherboard>> List(MotherboardQueryParameters parameters, CancellationToken cancellationToken = default) =>
        await db.Motherboards
            .AsNoTracking()
            .Include(p => p.Chipset)
            .Include(p => p.MotherboardBrand)
            .Include(p => p.Socket)
            .Filter(parameters)
            .Order(parameters)
            .Pagination(parameters)
            .ToListAsync(cancellationToken);

    public async Task<Motherboard?> Get(Guid id, CancellationToken cancellationToken = default) =>
        await db.Motherboards
            .AsNoTracking()
            .Include(p => p.Chipset)
            .Include(p => p.MotherboardBrand)
            .Include(p => p.Socket)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);

    public async Task<Motherboard> Create(Motherboard motherboard, CancellationToken cancellationToken = default)
    {
        db.Motherboards.Add(motherboard);
        await db.SaveChangesAsync(cancellationToken);
        return motherboard;
    }
    
    public async Task<Guid> Update(Motherboard motherboard, CancellationToken cancellationToken = default)
    {
        db.Motherboards.Update(motherboard);
        await db.SaveChangesAsync(cancellationToken);
        return motherboard.Id;
    }
}