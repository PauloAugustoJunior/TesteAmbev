namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.UpdateSaleItem;

/// <summary>
/// API response model for UpdateSaleItem operation
/// </summary>
public class UpdateSaleItemResponse
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
