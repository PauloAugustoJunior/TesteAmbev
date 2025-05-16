using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch;
using Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranch;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.UpdateBranch;

/// <summary>
/// Profile for mapping between Application and API UpdateBranch responses
/// </summary>
public class UpdateBranchProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateBranch feature
    /// </summary>
    public UpdateBranchProfile()
    {
        CreateMap<UpdateBranchRequest, UpdateBranchCommand>();
        CreateMap<UpdateBranchResult, UpdateBranchResponse>();
    }
}
