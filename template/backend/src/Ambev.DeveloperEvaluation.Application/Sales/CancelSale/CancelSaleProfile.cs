using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Profile for mapping between Sale entity and UpdateSaleResult.
/// </summary>
public class CancelSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for the UpdateSale operation.
    /// </summary>
    public CancelSaleProfile()
    {
        CreateMap<CancelSaleCommand, Sale>();
        CreateMap<Sale, CancelSaleResult>();
    }
}
