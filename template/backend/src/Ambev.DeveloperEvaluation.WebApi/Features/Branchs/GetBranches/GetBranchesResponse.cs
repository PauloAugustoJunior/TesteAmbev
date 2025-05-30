using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranch;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranches;

/// <summary>
/// Response model for a paginated list of branches
/// </summary>
public class GetBranchesResponse
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
    public IEnumerable<GetBranchResponse> Items { get; set; } = Enumerable.Empty<GetBranchResponse>();
}