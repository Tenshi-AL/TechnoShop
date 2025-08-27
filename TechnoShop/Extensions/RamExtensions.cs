using Domain.Models;
using TechnoShop.Models;

namespace TechnoShop.Extensions;

public static class RamExtensions
{
    public static IEnumerable<RAM> Filter(this IEnumerable<RAM> list, RAMQueryParameters options)
    {
        if (options.Brands != null && options.Brands.Count != 0)
            list = list.Where(p => options.Brands.Contains(p.BrandId));

        if (options.MemoryTypes != null && options.MemoryTypes.Count != 0)
            list = list.Where(p => options.MemoryTypes.Contains(p.MemoryTypeId));

        if (options.MinCapacity != null)
            list = list.Where(p => p.CapacityGB >= options.MinCapacity.Value);

        if (options.MaxCapacity != null)
            list = list.Where(p => p.CapacityGB <= options.MaxCapacity.Value);

        if (options.MinFrequency != null)
            list = list.Where(p => p.FrequencyMHz >= options.MinFrequency.Value);

        if (options.MaxFrequency != null)
            list = list.Where(p => p.FrequencyMHz <= options.MaxFrequency.Value);

        if (options.MinModuleCount != null)
            list = list.Where(p => p.ModuleCount >= options.MinModuleCount.Value);

        if (options.MaxModuleCount != null)
            list = list.Where(p => p.ModuleCount <= options.MaxModuleCount.Value);

        if (options.MinVoltage != null)
            list = list.Where(p => p.Voltage_V >= options.MinVoltage.Value);

        if (options.MaxVoltage != null)
            list = list.Where(p => p.Voltage_V <= options.MaxVoltage.Value);

        if (options.Heatsinks.HasValue)
            list = list.Where(p => p.Heatsinks == options.Heatsinks.Value);

        if (!string.IsNullOrEmpty(options.ECC))
            list = list.Where(p => p.ECC == options.ECC);

        if (!string.IsNullOrEmpty(options.Buffered))
            list = list.Where(p => p.Buffered == options.Buffered);

        if (!string.IsNullOrEmpty(options.Rank))
            list = list.Where(p => p.Rank == options.Rank);

        return list;
    }

    public static IEnumerable<RAM> Order(this IEnumerable<RAM> list, RAMQueryParameters options)
    {
        if (options.OrderRow is null) return list;
        
        return options.OrderRow.ToLower() switch
        {
            "name" => options.OrderByDesk ? list.OrderByDescending(p => p.Name) : list.OrderBy(p => p.Name),
            "price" => options.OrderByDesk ? list.OrderByDescending(p => p.Price) : list.OrderBy(p => p.Price),
            "capacity" => options.OrderByDesk ? list.OrderByDescending(p => p.CapacityGB) : list.OrderBy(p => p.CapacityGB),
            "frequency" => options.OrderByDesk ? list.OrderByDescending(p => p.FrequencyMHz) : list.OrderBy(p => p.FrequencyMHz),
            "modules" => options.OrderByDesk ? list.OrderByDescending(p => p.ModuleCount) : list.OrderBy(p => p.ModuleCount),
            "voltage" => options.OrderByDesk ? list.OrderByDescending(p => p.Voltage_V) : list.OrderBy(p => p.Voltage_V),
            _ => list
        };
    }
    
}