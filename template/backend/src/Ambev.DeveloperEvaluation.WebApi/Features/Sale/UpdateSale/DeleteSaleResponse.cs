namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// API response model for UpdateSale operation
/// </summary>
public class DeleteSaleResponse
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
