using System.ComponentModel.DataAnnotations;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a product category used to group and organize products within the system.
    /// Supports many-to-many relationships with products through the ProductCategory entity.
    /// </summary>
    public class Category : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the category.
        /// This field is required and should be unique and descriptive.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of product associations for this category.
        /// Enables many-to-many relationships between products and categories.
        /// </summary>
        public List<ProductCategory> ProductCategories { get; set; } = new();
    }
}
