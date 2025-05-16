using Ambev.DeveloperEvaluation.Application.Branchs.GetSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetSales;

/// <summary>
/// Profile for mapping GetSales feature requests to commands
/// </summary>
public class GetSalesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSales feature
    /// </summary>
    public GetSalesProfile()
    {
        CreateMap<GetSalesRequest, GetSalesQuery>();
        CreateMap<GetSalesResult, GetSalesResponse>()
            .ForMember(dest => dest.TotalItems, opt => opt.MapFrom(src => src.TotalCount))
            .ForMember(dest => dest.Page, opt => opt.MapFrom(src => src.CurrentPage))
            .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.PageSize))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.ToList()));

        CreateMap<GetSaleResult, GetSaleResponse>();
    }
}
