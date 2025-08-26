using Domain.Models;

namespace Domain.Interfaces;

public interface IGpuService
{
    Task<ICollection<GPU>> List(GpuQueryParameters gpuListOptions, CancellationToken cancellationToken);
    Task<GPU?> Get(Guid id, CancellationToken cancellationToken);
}