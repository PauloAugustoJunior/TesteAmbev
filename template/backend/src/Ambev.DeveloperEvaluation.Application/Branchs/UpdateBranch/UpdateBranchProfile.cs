using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch;

/// <summary>
/// Profile for mapping between Branch entity and UpdateBranchResult.
/// </summary>
public class UpdateBranchProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for the UpdateBranch operation.
    /// </summary>
    public UpdateBranchProfile()
    {
        CreateMap<UpdateBranchCommand, Branch>();
        CreateMap<Branch, UpdateBranchResult>();
    }
}
