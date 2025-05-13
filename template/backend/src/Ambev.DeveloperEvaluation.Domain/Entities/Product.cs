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
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the primary category name the product belongs to.
        /// Used for simple classification and filtering.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the image URL or path representing the product visually.
        /// This field is required and should link to a valid image resource.
        /// </summary>
        [Required]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the rating details for the product.
        /// Includes average score and total number of reviews.
        /// </summary>
        public Rating Rating { get; set; }

        /// <summary>
        /// Gets or sets the list of category associations for the product.
        /// Supports many-to-many relationships with categories.
        /// </summary>
        public List<ProductCategory> ProductCategories { get; set; } = new();
    }

    /// <summary>
    /// Represents the rating information for a product.
    /// Includes the average rate and the total number of reviews.
    /// </summary>
    public class Rating
    {
        /// <summary>
        /// Gets or sets the average rating score of the product.
        /// Usually ranges from 0.0 to 5.0.
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// Gets or sets the total number of ratings received by the product.
        /// Represents the sample size for the average rate.
        /// </summary>
        public int Count { get; set; }
    }
}
