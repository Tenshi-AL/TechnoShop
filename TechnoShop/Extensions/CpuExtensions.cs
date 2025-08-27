using System.Linq.Dynamic.Core;
using Domain.Models;
using TechnoShop.Models;

namespace TechnoShop.Extensions;

public static class CpuExtensions
{
    public static IEnumerable<Processor> Filter(this IEnumerable<Processor> list, ProcessorQueryParams options)
    {
        if (options.Sockets != null && options.Sockets.Count != 0)
            list = list.Where(p => options.Sockets.Contains(p.SocketId));

        if (options.ProcessorBrands != null && options.ProcessorBrands.Count != 0)
            list = list.Where(p => options.ProcessorBrands.Contains(p.ProcessorBrandId));

        if (options.MemoryTypes != null && options.MemoryTypes.Count != 0)
            list = list.Where(p => options.MemoryTypes.Contains(p.MemoryTypeId));

        if (options.MinFrequencyGHz != null)
            list = list.Where(p => p.BaseFrequencyGHz >= options.MinFrequencyGHz.Value);

        if (options.MaxFrequencyGHz != null)
            list = list.Where(p => p.BaseFrequencyGHz <= options.MaxFrequencyGHz.Value);

        if (options.MinCoresCount != null)
            list = list.Where(p => p.CoresCount >= options.MinCoresCount.Value);

        if (options.MaxCoresCount != null)
            list = list.Where(p => p.CoresCount <= options.MaxCoresCount.Value);

        if (options.MinThreadsCount != null)
            list = list.Where(p => p.ThreadsCount >= options.MinThreadsCount.Value);

        if (options.MaxThreadsCount != null)
            list = list.Where(p => p.ThreadsCount <= options.MaxThreadsCount.Value);

        if (options.MinCacheMB != null)
            list = list.Where(p => p.L3CacheMB >= options.MinCacheMB.Value);

        if (options.MaxCacheMB != null)
            list = list.Where(p => p.L3CacheMB <= options.MaxCacheMB.Value);

        if (options.MinTDP != null)
            list = list.Where(p => p.TDP_W >= options.MinTDP.Value);

        if (options.MaxTDP != null)
            list = list.Where(p => p.TDP_W <= options.MaxTDP.Value);

        if (options.MinProcessNM != null)
            list = list.Where(p => p.ProcessNM >= options.MinProcessNM.Value);

        if (options.MaxProcessNM != null)
            list = list.Where(p => p.ProcessNM <= options.MaxProcessNM.Value);

        if (options.IntegratedGPU.HasValue)
            list = list.Where(p => p.IntegratedGPU == options.IntegratedGPU.Value);

        if (options.HyperThreading.HasValue)
            list = list.Where(p => p.HyperThreading == options.HyperThreading.Value);

        if (options.UnlockedMultiplier.HasValue)
            list = list.Where(p => p.UnlockedMultiplier == options.UnlockedMultiplier.Value);

        return list;
    }

    public static IEnumerable<Processor> Order(this IEnumerable<Processor> list, ProcessorQueryParams options)
    {
        if (options.OrderRow is null) return list;
        
        return options.OrderRow.ToLower() switch
        {
            "name" => options.OrderByDesk ? list.OrderByDescending(p => p.Name) : list.OrderBy(p => p.Name),
            "price" => options.OrderByDesk ? list.OrderByDescending(p => p.Price) : list.OrderBy(p => p.Price),
            "frequency" => options.OrderByDesk ? list.OrderByDescending(p => p.BaseFrequencyGHz) : list.OrderBy(p => p.BaseFrequencyGHz),
            "cores" => options.OrderByDesk ? list.OrderByDescending(p => p.CoresCount) : list.OrderBy(p => p.CoresCount),
            "threads" => options.OrderByDesk ? list.OrderByDescending(p => p.ThreadsCount) : list.OrderBy(p => p.ThreadsCount),
            "cache" => options.OrderByDesk ? list.OrderByDescending(p => p.L3CacheMB) : list.OrderBy(p => p.L3CacheMB),
            "tdp" => options.OrderByDesk ? list.OrderByDescending(p => p.TDP_W) : list.OrderBy(p => p.TDP_W),
            _ => list
        };
    }
}