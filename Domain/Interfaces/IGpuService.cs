using Domain.Models;

namespace Domain.Interfaces;

public interface IGpuService
{
    Task<IEnumerable<GPU>> List(CancellationToken cancellationToken);
    Task<GPU?> Get(Guid id, CancellationToken cancellationToken);
    Task<GPU> Create(GPU gpu, CancellationToken cancellationToken);
    Task<Guid> Update(GPU gpu, CancellationToken cancellationToken);
}