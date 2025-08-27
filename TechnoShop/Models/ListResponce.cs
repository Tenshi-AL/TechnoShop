using TechnoShop.DTO;

namespace TechnoShop.Models;

public sealed class ListResponce<T>
{
    public ListResponce(IEnumerable<T> source, int pageIndex, int pageSize)
    {
        TotalCount = source.Count();
        TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
        PageIndex = pageIndex;
        PageSize = pageSize;
        HasPreviousPage = pageIndex > 1;
        HasNextPage = PageIndex < TotalPages;
        List = source.Skip((pageIndex - 1) * pageSize).Take(pageSize);
    }

    public IEnumerable<T> List { get; private set; }
    public int TotalCount { get; private set; } 
    public int TotalPages { get; private set; } 
    public int PageIndex { get; private set; }
    public int PageSize { get; private set; }
    public bool HasPreviousPage { get; private set; }
    public bool HasNextPage { get; private set; }
}