using Domain.Models;

namespace Domain.Interfaces;

public interface IPSUService
{
    Task<ICollection<PSU>> List(PSUQueryParameters parameters, CancellationToken cancellationToken = default);
    Task<PSU?> Get(Guid id, CancellationToken cancellationToken = default);
    Task<PSU> Create(PSU psu, CancellationToken cancellationToken = default);
    Task<Guid> Update(PSU psu, CancellationToken cancellationToken = default);
}