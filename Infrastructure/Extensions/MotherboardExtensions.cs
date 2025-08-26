using Domain.Models;

namespace Infrastructure.Extensions;

public static class MotherboardExtensions
{
    public static IQueryable<Motherboard> Filter(this IQueryable<Motherboard> list, MotherboardQueryParameters options)
    {
        if (options.Chipsets != null && options.Chipsets.Count != 0)
            list = list.Where(p => options.Chipsets.Contains(p.ChipsetId));

        if (options.MotherboardBrands != null && options.MotherboardBrands.Count != 0)
            list = list.Where(p => options.MotherboardBrands.Contains(p.MotherboardBrandId));

        if (options.Sockets != null && options.Sockets.Count != 0)
            list = list.Where(p => options.Sockets.Contains(p.SocketId));

        if (options.MinM2Slots != null)
            list = list.Where(p => p.M2Slots >= options.MinM2Slots.Value);

        if (options.MaxM2Slots != null)
            list = list.Where(p => p.M2Slots <= options.MaxM2Slots.Value);

        if (options.MinSATA3 != null)
            list = list.Where(p => p.SATA3 >= options.MinSATA3.Value);

        if (options.MaxSATA3 != null)
            list = list.Where(p => p.SATA3 <= options.MaxSATA3.Value);

        if (options.MinFanHeaders != null)
            list = list.Where(p => p.FanHeaders >= options.MinFanHeaders.Value);

        if (options.MaxFanHeaders != null)
            list = list.Where(p => p.FanHeaders <= options.MaxFanHeaders.Value);

        if (options.MinPCIe_x1 != null)
            list = list.Where(p => p.PCIe_x1 >= options.MinPCIe_x1.Value);

        if (options.MaxPCIe_x1 != null)
            list = list.Where(p => p.PCIe_x1 <= options.MaxPCIe_x1.Value);

        if (options.ReinforcedPCIESlot.HasValue)
            list = list.Where(p => p.ReinforcedPCIESlot == options.ReinforcedPCIESlot.Value);

        if (options.M2Cooling.HasValue)
            list = list.Where(p => p.M2Cooling == options.M2Cooling.Value);

        if (options.BIOSFlashBack.HasValue)
            list = list.Where(p => p.BIOSFlashBack == options.BIOSFlashBack.Value);

        if (!string.IsNullOrEmpty(options.FormFactor))
            list = list.Where(p => p.FormFactor == options.FormFactor);

        if (!string.IsNullOrEmpty(options.M2Type))
            list = list.Where(p => p.M2Type != null && p.M2Type.Contains(options.M2Type));

        return list;
    }

    public static IQueryable<Motherboard> Order(this IQueryable<Motherboard> list, MotherboardQueryParameters options)
    {
        if (options.OrderRow is null) return list;
        
        return options.OrderRow.ToLower() switch
        {
            "name" => options.OrderByDesk ? list.OrderByDescending(p => p.Name) : list.OrderBy(p => p.Name),
            "price" => options.OrderByDesk ? list.OrderByDescending(p => p.Price) : list.OrderBy(p => p.Price),
            "m2slots" => options.OrderByDesk ? list.OrderByDescending(p => p.M2Slots) : list.OrderBy(p => p.M2Slots),
            "sata3" => options.OrderByDesk ? list.OrderByDescending(p => p.SATA3) : list.OrderBy(p => p.SATA3),
            "fanheaders" => options.OrderByDesk ? list.OrderByDescending(p => p.FanHeaders) : list.OrderBy(p => p.FanHeaders),
            _ => list
        };
    }

    public static IQueryable<Motherboard> Pagination(this IQueryable<Motherboard> list, MotherboardQueryParameters options)
    {
        if (options.Page <= 0) options.Page = 1;
        if (options.PageSize <= 0) options.PageSize = 10;
        return list.Skip((options.Page - 1) * options.PageSize).Take(options.PageSize);
    }
}