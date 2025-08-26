using Domain.Models;

namespace Domain.Interfaces;

public interface IRAMService
{
    Task<ICollection<RAM>> List(RAMQueryParameters parameters, CancellationToken cancellationToken = default);
    Task<RAM?> Get(Guid id, CancellationToken cancellationToken = default);
    Task<RAM> Create(RAM ram, CancellationToken cancellationToken = default);
    Task<Guid> Update(RAM ram, CancellationToken cancellationToken = default);
}