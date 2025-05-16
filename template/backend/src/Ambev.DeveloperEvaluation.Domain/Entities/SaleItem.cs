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
        public double UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to this particular sale item.
        /// The discount is a percentage that reduces the final price of the product.
        /// </summary>
        public double Discount { get; set; }

        /// <summary>
        /// Gets or sets the total price for this sale item after applying the quantity and any discounts.
        /// This value is calculated as: (UnitPrice * Quantity) - Discount.
        /// </summary>
        public double Total { get; set; }

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

        public void Calculate()
        {
            ApplyBusinessRules();
            var partialTotal = UnitPrice * Quantity;
            Total = partialTotal - (partialTotal * Discount);
        }

        private void ApplyBusinessRules()
        {
            if (Quantity > 20)
            {
                throw new InvalidOperationException($"You cannot purchase more than 20 units of id product {ProductId}.");
            }

            if (Quantity < 4)
            {
                Discount = 0;
            }
            else
            {
                double discount = 0;
                if (Quantity >= 10 && Quantity <= 20)
                {
                    discount = 0.20;
                }
                else if (Quantity >= 4)
                {
                    discount = 0.10;
                }

                Discount = discount;
            }
        }
    }
    public struct ProductToQuantity
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public ProductToQuantity(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
