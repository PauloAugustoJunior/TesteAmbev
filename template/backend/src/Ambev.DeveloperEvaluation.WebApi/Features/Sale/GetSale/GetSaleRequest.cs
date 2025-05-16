namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// Request model for retrieving a branch by ID.
/// </summary>
public class GetSaleRequest
{
    /// <summary>
    /// The unique identifier of the branch to retrieve.
    /// </summary>
    public Guid Id { get; set; }
}
