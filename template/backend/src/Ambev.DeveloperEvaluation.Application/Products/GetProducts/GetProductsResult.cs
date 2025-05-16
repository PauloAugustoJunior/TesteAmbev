using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Response model for the GetProducts operation, containing a paginated list of branches.
/// </summary>
public class GetProductsResult : PaginatedList<GetProductResult>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetProductsResult"/> class with paginated branch data.
    /// </summary>
    /// <param name="items">The list of branch results.</param>
    /// <param name="count">The total number of available items.</param>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The number of items per page.</param>
    public GetProductsResult(List<GetProductResult> items, int count, int pageNumber, int pageSize) : base(items, count, pageNumber, pageSize)
    {
        
    }
}
