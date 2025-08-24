using Domain.Interfaces;
using Domain.Models;
using Persistence;

namespace Infrastructure.Services;

public class GpuService(TechnoShopContext db): IGpuService
{
    public ICollection<GPU> List()
    {
        return db.Gpus.ToList();
    }
}