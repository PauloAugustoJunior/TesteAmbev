using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Event notification triggered after a sale is created.
/// </summary>
public class CreateSaleEvent : INotification
{
    /// <summary>
    /// Gets the identifier of the created sale.
    /// </summary>
    public Guid SaleId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleEvent"/> class with the specified sale ID.
    /// </summary>
    /// <param name="saleId">The identifier of the created sale.</param>
    public CreateSaleEvent(Guid saleId)
    {
        SaleId = saleId;
    }
}
