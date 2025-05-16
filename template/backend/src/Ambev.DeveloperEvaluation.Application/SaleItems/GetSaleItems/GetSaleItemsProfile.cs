using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetSaleItems;

/// <summary>
/// Profile for mapping between User entity and GetSaleItemsResponse
/// </summary>
public class GetSaleItemsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSaleItems operation
    /// </summary>
    public GetSaleItemsProfile()
    {
        CreateMap<Branch, GetSaleItemsResult>();
    }
}
