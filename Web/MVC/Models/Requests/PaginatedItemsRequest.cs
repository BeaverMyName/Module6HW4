namespace MVC.Models.Requests;

public class PaginatedItemsRequest<T>
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }
    
    public Dictionary<T, int>? Filters { get; set; }
}