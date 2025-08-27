using Domain.Models;
using TechnoShop.Models;

namespace TechnoShop.Extensions;

public static class GpuExtensions
{
    public static IEnumerable<GPU> Filter(this IEnumerable<GPU> list, GpuQueryParameters options)
    {
        if (options.MinVramGb != null)
            list = list.Where(p => p.VRAM_GB >= options.MinVramGb.Value);

        if (options.MaxVramGb != null)
            list = list.Where(p => p.VRAM_GB <= options.MaxVramGb.Value);

        if (options.MemoryTypes != null && options.MemoryTypes.Count != 0)
            list = list.Where(p => options.MemoryTypes.Contains(p.MemoryTypeId));

        if (options.Manufacturers != null && options.Manufacturers.Count != 0)
            list = list.Where(p => options.Manufacturers.Contains(p.ManufacturerId));

        if (options.Brands != null && options.Brands.Count != 0)
            list = list.Where(p => options.Brands.Contains(p.BrandId));

        return list;
    }

    public static IEnumerable<GPU> Order(this IEnumerable<GPU> list, GpuQueryParameters options)
    {
        if (options.OrderRow is null) return list;
        return options.OrderRow.ToLower() switch
        {
            "name" => options.OrderByDesk ? list.OrderByDescending(p => p.Name) : list.OrderBy(p=>p.Name),
            "price" => options.OrderByDesk ? list.OrderByDescending(p => p.Price) : list.OrderBy(p=>p.Price),
            "vram" => options.OrderByDesk ? list.OrderByDescending(p => p.VRAM_GB) : list.OrderBy(p=>p.VRAM_GB),
            _ => list
        };
    }
    
}