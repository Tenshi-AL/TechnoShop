using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Services;

public class ProcessorService(TechnoShopContext db) : IProcessorService
{
    public async Task<ICollection<Processor>> List(CancellationToken cancellationToken = default) =>
        await db.Processors
            .AsNoTracking()
            .Include(p => p.Socket)
            .Include(p => p.ProcessorBrand)
            .Include(p => p.MemoryType)
            //.Filter(parameters)
            //.Order(parameters)
            //.Pagination(parameters)
            .ToListAsync(cancellationToken);

    public async Task<Processor?> Get(Guid id, CancellationToken cancellationToken = default) =>
        await db.Processors
            .AsNoTracking()
            .Include(p => p.Socket)
            .Include(p => p.ProcessorBrand)
            .Include(p => p.MemoryType)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);

    public async Task<Processor> Create(Processor processor, CancellationToken cancellationToken = default)
    {
        db.Processors.Add(processor);
        await db.SaveChangesAsync(cancellationToken);
        return processor;
    }
    
    public async Task<Guid> Update(Processor processor, CancellationToken cancellationToken = default)
    {
        db.Processors.Update(processor);
        await db.SaveChangesAsync(cancellationToken);
        return processor.Id;
    }
}