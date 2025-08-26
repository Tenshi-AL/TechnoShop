using Domain.Models;

namespace Infrastructure.Extensions;

public static class PSUExtensions
{
    public static IQueryable<PSU> Filter(this IQueryable<PSU> list, PSUQueryParameters options)
    {
        if (options.Brands != null && options.Brands.Count != 0)
            list = list.Where(p => options.Brands.Contains(p.BrandId));

        if (options.FormFactors != null && options.FormFactors.Count != 0)
            list = list.Where(p => options.FormFactors.Contains(p.FormFactorId));

        if (options.MinTotalPower != null)
            list = list.Where(p => p.TotalPower_W >= options.MinTotalPower.Value);

        if (options.MaxTotalPower != null)
            list = list.Where(p => p.TotalPower_W <= options.MaxTotalPower.Value);

        if (options.MinMolexCount != null)
            list = list.Where(p => p.MolexCount >= options.MinMolexCount.Value);

        if (options.MaxMolexCount != null)
            list = list.Where(p => p.MolexCount <= options.MaxMolexCount.Value);

        if (options.MinSATACount != null)
            list = list.Where(p => p.SATA_Count >= options.MinSATACount.Value);

        if (options.MaxSATACount != null)
            list = list.Where(p => p.SATA_Count <= options.MaxSATACount.Value);

        if (options.MinFanSize != null)
            list = list.Where(p => p.Fan_mm >= options.MinFanSize.Value);

        if (options.MaxFanSize != null)
            list = list.Where(p => p.Fan_mm <= options.MaxFanSize.Value);

        if (options.MinEfficiency != null)
            list = list.Where(p => p.EfficiencyPercent >= options.MinEfficiency.Value);

        if (options.MaxEfficiency != null)
            list = list.Where(p => p.EfficiencyPercent <= options.MaxEfficiency.Value);

        if (options.APFC.HasValue)
            list = list.Where(p => p.APFC == options.APFC.Value);

        if (options.ModularCables.HasValue)
            list = list.Where(p => p.ModularCables == options.ModularCables.Value);

        if (options.SemiPassiveCooling.HasValue)
            list = list.Where(p => p.SemiPassiveCooling == options.SemiPassiveCooling.Value);

        if (!string.IsNullOrEmpty(options.EfficiencyStandard))
            list = list.Where(p => p.EfficiencyStandard == options.EfficiencyStandard);

        if (!string.IsNullOrEmpty(options.ATXStandard))
            list = list.Where(p => p.ATXStandard == options.ATXStandard);

        return list;
    }

    public static IQueryable<PSU> Order(this IQueryable<PSU> list, PSUQueryParameters options)
    {
        if (options.OrderRow is null) return list;
        
        return options.OrderRow.ToLower() switch
        {
            "name" => options.OrderByDesk ? list.OrderByDescending(p => p.Name) : list.OrderBy(p => p.Name),
            "price" => options.OrderByDesk ? list.OrderByDescending(p => p.Price) : list.OrderBy(p => p.Price),
            "power" => options.OrderByDesk ? list.OrderByDescending(p => p.TotalPower_W) : list.OrderBy(p => p.TotalPower_W),
            "efficiency" => options.OrderByDesk ? list.OrderByDescending(p => p.EfficiencyPercent) : list.OrderBy(p => p.EfficiencyPercent),
            "fansize" => options.OrderByDesk ? list.OrderByDescending(p => p.Fan_mm) : list.OrderBy(p => p.Fan_mm),
            "molex" => options.OrderByDesk ? list.OrderByDescending(p => p.MolexCount) : list.OrderBy(p => p.MolexCount),
            "sata" => options.OrderByDesk ? list.OrderByDescending(p => p.SATA_Count) : list.OrderBy(p => p.SATA_Count),
            _ => list
        };
    }

    public static IQueryable<PSU> Pagination(this IQueryable<PSU> list, PSUQueryParameters options)
    {
        if (options.Page <= 0) options.Page = 1;
        if (options.PageSize <= 0) options.PageSize = 10;
        return list.Skip((options.Page - 1) * options.PageSize).Take(options.PageSize);
    }
}