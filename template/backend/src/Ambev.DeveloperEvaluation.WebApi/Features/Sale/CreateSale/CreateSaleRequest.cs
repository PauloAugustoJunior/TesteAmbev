namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new Sale in the system.
/// </summary>
public class CreateSaleRequest
{
    public Guid UserId { get; set; }
    public DateTimeOffset Date { get; set; }
    public List<SaleProductRequest> Products { get; set; } = new();
}

public class SaleProductRequest
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}

