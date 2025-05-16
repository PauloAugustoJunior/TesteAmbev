using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;

/// <summary>
/// Command for retrieving a branch by their ID
/// </summary>
public record GetSaleItemQuery : IRequest<GetSaleItemResult>
{
    /// <summary>
    /// The unique identifier of the branch to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetSaleItemQuery
    /// </summary>
    /// <param name="id">The ID of the branch to retrieve</param>
    public GetSaleItemQuery(Guid id)
    {
        Id = id;
    }
}
