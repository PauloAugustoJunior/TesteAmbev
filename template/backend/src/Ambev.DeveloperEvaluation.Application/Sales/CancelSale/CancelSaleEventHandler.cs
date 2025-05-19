using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Event handler that is triggered after a sale is canceled.
/// </summary>
public class CancelSaleEventHandler : INotificationHandler<CancelSaleEvent>
{
    private readonly ILogger<CancelSaleEventHandler> _logger;

    /// <summary>
    /// Constructor that injects the logger instance.
    /// </summary>
    /// <param name="logger">Logger instance for logging information.</param>
    public CancelSaleEventHandler(ILogger<CancelSaleEventHandler> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Handles the CancelSaleEvent.
    /// </summary>
    /// <param name="notification">Event containing the data of the canceled sale.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Handle(CancelSaleEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sale {SaleId} was successfully canceled.", notification.SaleId);
        return Task.CompletedTask;
    }
}
