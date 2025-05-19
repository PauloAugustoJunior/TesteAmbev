using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetSales;

/// <summary>
/// Profile for mapping between User entity and GetSalesResponse
/// </summary>
public class GetSalesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSales operation
    /// </summary>
    public GetSalesProfile()
    {
        CreateMap<Sale, GetSalesResult>();
    }
}
