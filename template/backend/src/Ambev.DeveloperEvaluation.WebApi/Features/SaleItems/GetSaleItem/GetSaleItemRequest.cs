namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;

/// <summary>
/// Request model for retrieving a branch by ID.
/// </summary>
public class GetSaleItemRequest
{
    /// <summary>
    /// The unique identifier of the branch to retrieve.
    /// </summary>
    public Guid Id { get; set; }
}
