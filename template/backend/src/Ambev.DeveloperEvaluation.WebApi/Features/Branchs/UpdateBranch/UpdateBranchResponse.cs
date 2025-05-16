namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.UpdateBranch;

/// <summary>
/// API response model for UpdateBranch operation
/// </summary>
public class UpdateBranchResponse
{
    /// <summary>
    /// The unique identifier of the updated branch
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The name of the updated branch
    /// </summary>
    public string Name { get; set; }
}
