using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranches;

/// <summary>
/// Command for retrieving a user by their ID
/// </summary>
public record GetBranchesQuery : IRequest<GetBranchesResult>
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
    /// Initializes a new instance of GetBranchesQuery
    /// </summary>
    /// <param name="id">The ID of the user to retrieve</param>
    public GetBranchesQuery(int Page, int Size, string? Order)
    {
        this.Page = Page;
        this.Size = Size;
        this.Order = Order;
    }
}
