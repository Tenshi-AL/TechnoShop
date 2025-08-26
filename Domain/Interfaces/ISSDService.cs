using Domain.Models;

namespace Domain.Interfaces;

public interface ISSDService
{
    Task<ICollection<SSD>> List(SSDQueryParameters parameters, CancellationToken cancellationToken = default);
    Task<SSD?> Get(Guid id, CancellationToken cancellationToken = default);
    Task<SSD> Create(SSD ssd, CancellationToken cancellationToken = default);
    Task<Guid> Update(SSD ssd, CancellationToken cancellationToken = default);
}