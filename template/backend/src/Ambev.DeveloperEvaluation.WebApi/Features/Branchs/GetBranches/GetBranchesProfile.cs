using Ambev.DeveloperEvaluation.Application.Branchs.GetBranches;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranch;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranches;

/// <summary>
/// Profile for mapping GetBranches feature requests to commands
/// </summary>
public class GetBranchesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetBranches feature
    /// </summary>
    public GetBranchesProfile()
    {
        CreateMap<GetBranchesRequest, GetBranchesQuery>();
        CreateMap<GetBranchesResult, GetBranchesResponse>()
            .ForMember(dest => dest.TotalItems, opt => opt.MapFrom(src => src.TotalCount))
            .ForMember(dest => dest.Page, opt => opt.MapFrom(src => src.CurrentPage))
            .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.PageSize))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
        CreateMap<PaginatedResult<GetBranchResponse>, PaginatedResponse<GetBranchResponse>>();
    }
}
