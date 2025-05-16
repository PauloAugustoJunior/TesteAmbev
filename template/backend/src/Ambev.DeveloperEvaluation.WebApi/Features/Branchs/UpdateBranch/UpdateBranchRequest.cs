namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.UpdateBranch;

/// <summary>
/// Represents a request to create a new branch in the system.
/// </summary>
public class UpdateBranchRequest
{
    /// <summary>
    /// Gets or sets the name of the branch.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
