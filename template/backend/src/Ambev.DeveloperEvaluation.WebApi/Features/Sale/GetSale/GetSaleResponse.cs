using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleResponse
{
    public Guid Id { get; set; }

    public long SaleNumber { get; set; }

    public DateTimeOffset SaleDate { get; set; }

    public Guid UserId { get; set; }

    public Guid BranchId { get; set; }

    public decimal TotalAmount { get; set; }

    public bool IsCancelled { get; set; }

    public List<GetSaleItemResponse> SaleItems { get; set; } = new();
}
