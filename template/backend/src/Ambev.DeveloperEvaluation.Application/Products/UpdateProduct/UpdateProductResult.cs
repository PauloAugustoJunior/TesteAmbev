namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Represents the response returned after successfully updating a branch.
/// </summary>
/// <remarks>
/// This response contains the unique identifier and name of the updated branch,
/// which can be used for confirmation or subsequent operations.
/// </remarks>
public class UpdateProductResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the updated branch.
    /// </summary>
    /// <value>A GUID that uniquely identifies the updated branch in the system.</value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the product.
    /// This field is required and should be descriptive for customer display.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// This field is required and must be a positive value.
    /// </summary>
    public double? Price { get; set; }

    /// <summary>
    /// Gets or sets the optional description of the product.
    /// Used to provide additional information or specifications.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the image URL or path representing the product visually.
    /// This field is required and should link to a valid image resource.
    /// </summary>
    public string? Image { get; set; }

    public string? Category { get; set; }
}
