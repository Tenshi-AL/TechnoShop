using Domain.Models;

namespace Domain.Interfaces;

public interface IProcessorService
{
    Task<ICollection<Processor>> List(CancellationToken cancellationToken);
    Task<Processor?> Get(Guid id, CancellationToken cancellationToken);
    Task<Processor> Create(Processor gpu, CancellationToken cancellationToken);
    Task<Guid> Update(Processor gpu, CancellationToken cancellationToken);
}