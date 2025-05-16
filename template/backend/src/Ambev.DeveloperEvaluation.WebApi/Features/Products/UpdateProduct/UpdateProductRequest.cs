namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

/// <summary>
/// Represents a request to create a new branch in the system.
/// </summary>
public class UpdateProductRequest
{
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
