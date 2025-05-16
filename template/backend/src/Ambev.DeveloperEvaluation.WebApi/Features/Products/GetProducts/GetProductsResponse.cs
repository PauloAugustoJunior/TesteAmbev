using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

/// <summary>
/// Response model for a paginated list of Products
/// </summary>
public class GetProductsResponse
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
    /// The list of branch items returned for the current page
    /// </summary>
    public IEnumerable<GetProductResponse> Items { get; set; } = Enumerable.Empty<GetProductResponse>();
}