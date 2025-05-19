using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Represents a domain event that is triggered when a sale is canceled.
/// </summary>
public class CancelSaleEvent : INotification
{
    /// <summary>
    /// Gets the identifier of the canceled sale.
    /// </summary>
    public Guid SaleId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CancelSaleEvent"/> class with the specified sale ID.
    /// </summary>
    /// <param name="saleId">The identifier of the canceled sale.</param>
    public CancelSaleEvent(Guid saleId)
    {
        SaleId = saleId;
    }
}
