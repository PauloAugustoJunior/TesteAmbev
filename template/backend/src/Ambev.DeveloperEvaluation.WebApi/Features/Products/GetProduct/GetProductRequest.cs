namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// Request model for retrieving a branch by ID.
/// </summary>
public class GetProductRequest
{
    /// <summary>
    /// The unique identifier of the branch to retrieve.
    /// </summary>
    public Guid Id { get; set; }
}
