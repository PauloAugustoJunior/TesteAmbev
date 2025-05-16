namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetSales;

/// <summary>
/// Request model for retrieving a paginated list of branches
/// </summary>
public class GetSalesRequest
{
    /// <summary>
    /// The page number to retrieve (default is 1)
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// The number of items per page (default is 10)
    /// </summary>
    public int Size { get; set; } = 10;

    /// <summary>
    /// The ordering criteria (optional)
    /// </summary>
    public string? Order { get; set; }
}