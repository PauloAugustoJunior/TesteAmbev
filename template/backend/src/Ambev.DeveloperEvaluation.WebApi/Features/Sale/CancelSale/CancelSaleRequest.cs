namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

public class CancelSaleRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the sale to be canceled.
    /// </summary>
    /// <value>The unique identifier (GUID) of the sale.</value>
    public Guid Id { get; set; }
}
