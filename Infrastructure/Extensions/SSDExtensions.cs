using Domain.Models;

namespace Infrastructure.Extensions;

public static class SSDExtensions
{
    public static IQueryable<SSD> Filter(this IQueryable<SSD> list, SSDQueryParameters options)
    {
        if (options.Brands != null && options.Brands.Count != 0)
            list = list.Where(p => options.Brands.Contains(p.BrandId));

        if (options.FormFactors != null && options.FormFactors.Count != 0)
            list = list.Where(p => options.FormFactors.Contains(p.FormFactorId));

        if (options.MinCapacity != null)
            list = list.Where(p => p.CapacityGB >= options.MinCapacity.Value);

        if (options.MaxCapacity != null)
            list = list.Where(p => p.CapacityGB <= options.MaxCapacity.Value);

        if (options.MinReadSpeed != null)
            list = list.Where(p => p.MaxReadMBs >= options.MinReadSpeed.Value);

        if (options.MaxReadSpeed != null)
            list = list.Where(p => p.MaxReadMBs <= options.MaxReadSpeed.Value);

        if (options.MinWriteSpeed != null)
            list = list.Where(p => p.MaxWriteMBs >= options.MinWriteSpeed.Value);

        if (options.MaxWriteSpeed != null)
            list = list.Where(p => p.MaxWriteMBs <= options.MaxWriteSpeed.Value);

        if (options.MinTBW != null)
            list = list.Where(p => p.TBW >= options.MinTBW.Value);

        if (options.MaxTBW != null)
            list = list.Where(p => p.TBW <= options.MaxTBW.Value);

        if (options.MinMTBF != null)
            list = list.Where(p => p.MTBF_MillionHours >= options.MinMTBF.Value);

        if (options.MaxMTBF != null)
            list = list.Where(p => p.MTBF_MillionHours <= options.MaxMTBF.Value);

        if (options.MinWeight != null)
            list = list.Where(p => p.Weight_g >= options.MinWeight.Value);

        if (options.MaxWeight != null)
            list = list.Where(p => p.Weight_g <= options.MaxWeight.Value);

        if (options.TRIMSupport.HasValue)
            list = list.Where(p => p.TRIMSupport == options.TRIMSupport.Value);

        if (!string.IsNullOrEmpty(options.Interface))
            list = list.Where(p => p.Interface == options.Interface);

        if (!string.IsNullOrEmpty(options.NANDType))
            list = list.Where(p => p.NANDType == options.NANDType);

        if (!string.IsNullOrEmpty(options.Series))
            list = list.Where(p => p.Series != null && p.Series.Contains(options.Series));

        return list;
    }

    public static IQueryable<SSD> Order(this IQueryable<SSD> list, SSDQueryParameters options)
    {
        if (options.OrderRow is null) return list;
        
        return options.OrderRow.ToLower() switch
        {
            "name" => options.OrderByDesk ? list.OrderByDescending(p => p.Name) : list.OrderBy(p => p.Name),
            "price" => options.OrderByDesk ? list.OrderByDescending(p => p.Price) : list.OrderBy(p => p.Price),
            "capacity" => options.OrderByDesk ? list.OrderByDescending(p => p.CapacityGB) : list.OrderBy(p => p.CapacityGB),
            "readspeed" => options.OrderByDesk ? list.OrderByDescending(p => p.MaxReadMBs) : list.OrderBy(p => p.MaxReadMBs),
            "writespeed" => options.OrderByDesk ? list.OrderByDescending(p => p.MaxWriteMBs) : list.OrderBy(p => p.MaxWriteMBs),
            "tbw" => options.OrderByDesk ? list.OrderByDescending(p => p.TBW) : list.OrderBy(p => p.TBW),
            "mtbf" => options.OrderByDesk ? list.OrderByDescending(p => p.MTBF_MillionHours) : list.OrderBy(p => p.MTBF_MillionHours),
            "weight" => options.OrderByDesk ? list.OrderByDescending(p => p.Weight_g) : list.OrderBy(p => p.Weight_g),
            _ => list
        };
    }

    public static IQueryable<SSD> Pagination(this IQueryable<SSD> list, SSDQueryParameters options)
    {
        if (options.Page <= 0) options.Page = 1;
        if (options.PageSize <= 0) options.PageSize = 10;
        return list.Skip((options.Page - 1) * options.PageSize).Take(options.PageSize);
    }
}