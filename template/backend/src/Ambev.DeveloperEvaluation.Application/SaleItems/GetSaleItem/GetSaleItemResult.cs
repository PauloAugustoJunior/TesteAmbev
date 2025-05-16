namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;

public class GetSaleItemResult
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public double Discount { get; set; }

    public double Total { get; set; }
}
