namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem;

/// <summary>
/// Represents the response returned after successfully updating a branch.
/// </summary>
/// <remarks>
/// This response contains the unique identifier and name of the updated branch,
/// which can be used for confirmation or subsequent operations.
/// </remarks>
public class DeleteSaleItemResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the updated branch.
    /// </summary>
    /// <value>A GUID that uniquely identifies the updated branch in the system.</value>
    public List<Guid> ListId { get; set; }

}
