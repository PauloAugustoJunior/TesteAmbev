namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents the association between a product and a category.
    /// This class defines a many-to-many relationship in the domain model.
    /// </summary>
    public class ProductCategory
    {
        /// <summary>
        /// Gets or sets the unique identifier of the associated product.
        /// Serves as a foreign key reference.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product entity linked to the category.
        /// Represents the product side of the relationship.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the associated category.
        /// Serves as a foreign key reference.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category entity linked to the product.
        /// Represents the category side of the relationship.
        /// </summary>
        public Category Category { get; set; }
    }
}
