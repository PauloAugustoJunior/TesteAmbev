using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Event handler that is triggered after a sale is deleted.
/// </summary>
public class DeleteSaleEventHandler : INotificationHandler<DeleteSaleEvent>
{
    private readonly ILogger<DeleteSaleEventHandler> _logger;

    /// <summary>
    /// Constructor that injects the logger instance.
    /// </summary>
    /// <param name="logger">Logger instance for logging information.</param>
    public DeleteSaleEventHandler(ILogger<DeleteSaleEventHandler> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Handles the DeleteSaleEvent.
    /// </summary>
    /// <param name="notification">Event containing the data of the deleted sale.</param>
    /// <param name="cancellationToken">Token to cancel the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Handle(DeleteSaleEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sale {SaleId} was successfully deleted.", notification.SaleId);
        return Task.CompletedTask;
    }
}
