using System.ComponentModel.DataAnnotations;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a product available in the system with details.
    /// Includes metadata for display and categorization, following domain-driven design principles.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the product.
        /// This field is required and should be descriptive for customer display.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// This field is required and must be a positive value.
        /// </summary>
        [Required]
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the optional description of the product.
        /// Used to provide additional information or specifications.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the image URL or path representing the product visually.
        /// This field is required and should link to a valid image resource.
        /// </summary>
        [Required]
        public string Image { get; set; }

        [Required]
        public string Category { get; set; }

        public Guid BranchId { get; set; }

        public Branch Branch { get; set; }
    }

}
