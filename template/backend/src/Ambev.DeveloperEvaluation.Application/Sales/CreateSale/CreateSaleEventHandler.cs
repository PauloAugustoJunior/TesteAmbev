using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Event handler that is triggered after a sale is created.
/// </summary>
public class CreateSaleEventHandler : INotificationHandler<CreateSaleEvent>
{
    private readonly ILogger<CreateSaleEventHandler> _logger;

    /// <summary>
    /// Constructor that injects the logger.
    /// </summary>
    /// <param name="logger">Logger instance for logging information.</param>
    public CreateSaleEventHandler(ILogger<CreateSaleEventHandler> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Handles the CreateSaleEvent.
    /// </summary>
    /// <param name="notification">Event containing the data of the created sale.</param>
    /// <param name="cancellationToken">Token for canceling the asynchronous operation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Handle(CreateSaleEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Sale {SaleId} created successfully.", notification.SaleId);
        return Task.CompletedTask;
    }
}