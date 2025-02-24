public class PaginationParams
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class Paginate<T>
{
    public IList<T> Items { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;

    public Paginate()
    {
        Items = new List<T>();
    }

    public Paginate(IList<T> items, int totalItems, PaginationParams paginationParams)
    {
        Items = items;
        TotalItems = totalItems;
        PageNumber = paginationParams.PageNumber;
        PageSize = paginationParams.PageSize;
        TotalPages = (int)Math.Ceiling(TotalItems / (double)PageSize);
    }
} 