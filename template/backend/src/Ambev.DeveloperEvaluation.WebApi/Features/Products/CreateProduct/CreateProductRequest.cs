using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Represents a request to create a new product in the system.
/// </summary>
public class CreateProductRequest
{
    /// <summary>
    /// Gets or sets the title of the product.
    /// </summary>
    [Required]
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    [Required]
    public double Price { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the image URL or path for the product.
    /// </summary>
    [Required]
    public string Image { get; set; }

    [Required]
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets the branch ID to which this product belongs.
    /// </summary>
    [Required]
    public Guid BranchId { get; set; }
}
