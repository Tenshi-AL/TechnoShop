using Domain.Models;

namespace Domain.Interfaces;

public interface IGpuService
{
    ICollection<GPU> List();
}