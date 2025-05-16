using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Command for retrieving a branch by their ID
/// </summary>
public record GetProductQuery : IRequest<GetProductResult>
{
    /// <summary>
    /// The unique identifier of the branch to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetProductQuery
    /// </summary>
    /// <param name="id">The ID of the branch to retrieve</param>
    public GetProductQuery(Guid id)
    {
        Id = id;
    }
}
