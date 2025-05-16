namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

/// <summary>
/// API response model for CreateSaleItem operation
/// </summary>
public class CreateSaleItemResponse
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
