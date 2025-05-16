using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

/// <summary>
/// Profile for mapping GetProducts feature requests to commands
/// </summary>
public class GetProductsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetProducts feature
    /// </summary>
    public GetProductsProfile()
    {
        CreateMap<GetProductsRequest, GetProductsQuery>();
        CreateMap<GetProductsResult, GetProductsResponse>()
            .ForMember(dest => dest.TotalItems, opt => opt.MapFrom(src => src.TotalCount))
            .ForMember(dest => dest.Page, opt => opt.MapFrom(src => src.CurrentPage))
            .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.PageSize))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
        CreateMap<PaginatedResult<GetProductResponse>, PaginatedResponse<GetProductResponse>>();
    }
}
