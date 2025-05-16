using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Command for retrieving a branch by their ID
/// </summary>
public record GetSaleQuery : IRequest<GetSaleResult>
{
    /// <summary>
    /// The unique identifier of the branch to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetSaleQuery
    /// </summary>
    /// <param name="id">The ID of the branch to retrieve</param>
    public GetSaleQuery(Guid id)
    {
        Id = id;
    }
}
