using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleResult
{
    public Guid Id { get; set; }

    public long SaleNumber { get; set; }

    public DateTimeOffset SaleDate { get; set; }

    public Guid UserId { get; set; }

    public Guid BranchId { get; set; }

    public decimal TotalAmount { get; set; }

    public bool IsCancelled { get; set; }

    public List<GetSaleItemResult> SaleItems { get; set; } = new();

}
