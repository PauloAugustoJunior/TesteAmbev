using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranch;

public class GetBranchResponse
{
    /// <summary>
    /// The unique identifier of the branch.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The name of the branch.
    /// </summary>
    public string Name { get; set; } = string.Empty;

}
