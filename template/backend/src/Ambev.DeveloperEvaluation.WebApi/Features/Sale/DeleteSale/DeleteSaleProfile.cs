using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

/// <summary>
/// Profile for mapping between Application and API UpdateSale responses
/// </summary>
public class DeleteSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateSale feature
    /// </summary>
    public DeleteSaleProfile()
    {
        CreateMap<DeleteSaleRequest, DeleteSaleCommand>();
        CreateMap<DeleteSaleResult, DeleteSaleResponse>();
    }
}
