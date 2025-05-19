namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

/// <summary>
/// Represents a request to delete a sale in the system.
/// </summary>
public class DeleteSaleRequest
{
    /// <summary>
    /// Gets or sets the id of the sale.
    /// </summary>
    public Guid Id { get; set; }
}
