using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

/// <summary>
/// Command for retrieving a branch by their ID
/// </summary>
public record GetBranchQuery : IRequest<GetBranchResult>
{
    /// <summary>
    /// The unique identifier of the branch to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetBranchQuery
    /// </summary>
    /// <param name="id">The ID of the branch to retrieve</param>
    public GetBranchQuery(Guid id)
    {
        Id = id;
    }
}
