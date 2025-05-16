using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem;

/// <summary>
/// Profile for mapping between SaleItem entity and DeleteSaleItemResult.
/// </summary>
public class DeleteSaleItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for the DeleteSaleItem operation.
    /// </summary>
    public DeleteSaleItemProfile()
    {
        CreateMap<DeleteSaleItemCommand, SaleItem>();
        CreateMap<SaleItem, DeleteSaleItemResult>();
    }
}
