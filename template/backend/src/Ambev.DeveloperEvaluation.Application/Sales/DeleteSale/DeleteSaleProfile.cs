using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Profile for mapping between Sale entity and UpdateSaleResult.
/// </summary>
public class DeleteSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for the UpdateSale operation.
    /// </summary>
    public DeleteSaleProfile()
    {
        CreateMap<DeleteSaleCommand, Sale>();
        CreateMap<Sale, DeleteSaleResult>();
    }
}
