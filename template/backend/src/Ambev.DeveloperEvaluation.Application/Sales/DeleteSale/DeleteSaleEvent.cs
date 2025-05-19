using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Represents a domain event that is triggered when a sale is deleted.
/// </summary>
public class DeleteSaleEvent : INotification
{
    /// <summary>
    /// Gets the identifier of the deleted sale.
    /// </summary>
    public Guid SaleId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteSaleEvent"/> class with the specified sale ID.
    /// </summary>
    /// <param name="saleId">The identifier of the deleted sale.</param>
    public DeleteSaleEvent(Guid saleId)
    {
        SaleId = saleId;
    }
}
