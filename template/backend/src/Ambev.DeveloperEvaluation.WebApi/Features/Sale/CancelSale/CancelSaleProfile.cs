using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

/// <summary>
/// Profile for mapping between Application and API UpdateSale responses
/// </summary>
public class CancelSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateSale feature
    /// </summary>
    public CancelSaleProfile()
    {
        CreateMap<CancelSaleRequest, CancelSaleCommand>();
        CreateMap<CancelSaleResult, CancelSaleResponse>();
    }
}
