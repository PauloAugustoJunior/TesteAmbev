using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents an item in a sale transaction.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class SaleItem : BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier of the product being sold.
        /// This foreign key refers to the Product entity, which contains detailed information about the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product related to this sale item.
        /// This navigation property enables access to the Product entity
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product being sold in this sale item.
        /// This field represents how many units of the product are included in the sale.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// This field represents the price for a single unit of the product before applying any discounts.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to this particular sale item.
        /// The discount is a percentage that reduces the final price of the product.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Gets or sets the total price for this sale item after applying the quantity and any discounts.
        /// This value is calculated as: (UnitPrice * Quantity) - Discount.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the sale to which this sale item belongs.
        /// This foreign key links this sale item to a specific sale record in the system.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Gets or sets the sale associated with this sale item.
        /// This navigation property enables access to the Sale entity
        /// </summary>
        public Sale Sale { get; set; }
    }
}
