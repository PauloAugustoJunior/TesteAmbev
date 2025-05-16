using Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranches;

/// <summary>
/// Response model for the GetBranches operation, containing a paginated list of branches.
/// </summary>
public class GetBranchesResult : PaginatedList<GetBranchResult>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetBranchesResult"/> class with paginated branch data.
    /// </summary>
    /// <param name="items">The list of branch results.</param>
    /// <param name="count">The total number of available items.</param>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The number of items per page.</param>
    public GetBranchesResult(List<GetBranchResult> items, int count, int pageNumber, int pageSize) : base(items, count, pageNumber, pageSize)
    {
        
    }
}
