namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;

public class GetSaleItemResponse
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public double Discount { get; set; }

    public double Total { get; set; }
}
