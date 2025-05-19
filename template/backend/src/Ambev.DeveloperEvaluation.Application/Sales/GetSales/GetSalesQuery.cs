using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetSales;

/// <summary>
/// Command for retrieving a user by their ID
/// </summary>
public record GetSalesQuery : IRequest<List<GetSaleResult>>
{
    /// <summary>
    /// The page number to retrieve (default is 1)
    /// </summary>
    public int Page { get; } = 1;

    /// <summary>
    /// The number of items per page (default is 10)
    /// </summary>
    public int Size { get; } = 10;

    /// <summary>
    /// The ordering criteria (optional)
    /// </summary>
    public string? Order { get; }
    /// <summary>
    /// Initializes a new instance of GetSalesQuery
    /// </summary>
    public GetSalesQuery(int Page, int Size, string? Order)
    {
        this.Page = Page;
        this.Size = Size;
        this.Order = Order;
    }
}
