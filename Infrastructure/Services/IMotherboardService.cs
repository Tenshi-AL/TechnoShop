using Domain.Models;

namespace Infrastructure.Services;

public interface IMotherboardService
{
    Task<ICollection<Motherboard>> List(MotherboardQueryParameters parameters, CancellationToken cancellationToken = default);
    Task<Motherboard?> Get(Guid id, CancellationToken cancellationToken = default);
    Task<Motherboard> Create(Motherboard motherboard, CancellationToken cancellationToken = default);
    Task<Guid> Update(Motherboard motherboard, CancellationToken cancellationToken = default);
}