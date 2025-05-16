using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Profile for mapping between User entity and GetProductsResponse
/// </summary>
public class GetProductsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetProducts operation
    /// </summary>
    public GetProductsProfile()
    {
        CreateMap<Product, GetProductsResult>();
    }
}
