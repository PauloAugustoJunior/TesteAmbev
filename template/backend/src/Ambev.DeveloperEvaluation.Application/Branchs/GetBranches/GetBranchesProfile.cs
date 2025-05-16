using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranches;

/// <summary>
/// Profile for mapping between User entity and GetBranchesResponse
/// </summary>
public class GetBranchesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetBranches operation
    /// </summary>
    public GetBranchesProfile()
    {
        CreateMap<Branch, GetBranchesResult>();
    }
}
