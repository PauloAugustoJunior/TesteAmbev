using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetSales;

/// <summary>
/// Response model for a paginated list of branches
/// </summary>
public class GetSalesResponse
{
    /// <summary>
    /// The total number of items available
    /// </summary>
    public int TotalItems { get; set; }

    /// <summary>
    /// The current page number
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// The number of items per page
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// The list of sale items returned for the current page
    /// </summary>
    public IEnumerable<GetSaleResponse> Items { get; set; } = Enumerable.Empty<GetSaleResponse>();
}