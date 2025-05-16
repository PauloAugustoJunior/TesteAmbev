namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Represents the response returned after successfully updating a branch.
/// </summary>
/// <remarks>
/// This response contains the unique identifier and name of the updated branch,
/// which can be used for confirmation or subsequent operations.
/// </remarks>
public class DeleteSaleResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the updated branch.
    /// </summary>
    /// <value>A GUID that uniquely identifies the updated branch in the system.</value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the updated branch.
    /// </summary>
    /// <value>The updated name of the branch.</value>
    public string Name { get; set; }
}
