using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetSales;

/// <summary>
/// Command for retrieving a user by their ID
/// </summary>
public record GetSalesQuery : IRequest<List<GetSaleResult>>
{
    /// <summary>
    /// Initializes a new instance of GetSalesQuery
    /// </summary>
    /// <param name="id">The ID of the user to retrieve</param>
    public GetSalesQuery()
    {
        
    }
}
