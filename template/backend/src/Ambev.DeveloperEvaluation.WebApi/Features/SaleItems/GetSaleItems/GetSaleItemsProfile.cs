using Ambev.DeveloperEvaluation.Application.Branchs.GetSaleItems;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranch;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetSaleItems;

/// <summary>
/// Profile for mapping GetSaleItems feature requests to commands
/// </summary>
public class GetSaleItemsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSaleItems feature
    /// </summary>
    public GetSaleItemsProfile()
    {
        CreateMap<GetSaleItemsRequest, GetSaleItemsQuery>();
        CreateMap<GetSaleItemsResult, GetSaleItemsResponse>()
            .ForMember(dest => dest.TotalItems, opt => opt.MapFrom(src => src.TotalCount))
            .ForMember(dest => dest.Page, opt => opt.MapFrom(src => src.CurrentPage))
            .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.PageSize))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
        CreateMap<PaginatedResult<GetBranchResponse>, PaginatedResponse<GetBranchResponse>>();
    }
}
