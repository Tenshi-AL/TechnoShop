using Domain.Models;

namespace Infrastructure.Extensions;

public static class GpuExtensions
{
    public static IQueryable<GPU> Filter(this IQueryable<GPU> list, GpuQueryParameters options)
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

    public static IQueryable<GPU> Order(this IQueryable<GPU> list, GpuQueryParameters options)
    {
        if (options.OrderRow is null) return list;
        return options.OrderRow switch
        {
            "Name" => options.OrderByDesk ? list.OrderByDescending(p => p.Name) : list.OrderBy(p=>p.Name),
            "Price" => options.OrderByDesk ? list.OrderByDescending(p => p.Price) : list.OrderBy(p=>p.Price),
            "VRAM" => options.OrderByDesk ? list.OrderByDescending(p => p.VRAM_GB) : list.OrderBy(p=>p.VRAM_GB),
            _ => list
        };
    }

    public static IQueryable<GPU> Pagination(this IQueryable<GPU> list, GpuQueryParameters options)
    {
        if (options.Page <= 0) options.Page = 1;
        if (options.PageSize <= 0) options.PageSize = 5;
        return list.Skip((options.Page - 1) * options.PageSize).Take(options.PageSize);
    }
}