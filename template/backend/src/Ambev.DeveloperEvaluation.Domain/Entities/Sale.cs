using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale transaction in the system, including metadata and relationships with other entities.
    /// This entity follows domain-driven design principles.
    /// </summary>
    public class Sale : BaseEntity
    {
        /// <summary>
        /// Gets or sets the sequential number assigned to the sale.
        /// Used for referencing and tracking purposes.
        /// </summary>
        public long SaleNumber { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the sale occurred.
        /// Uses DateTimeOffset to support time zone-aware operations.
        /// </summary>
        public DateTimeOffset SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the user who performed the sale.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user entity associated with the sale.
        /// Represents the customer involved in the transaction.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the branch where the sale occurred.
        /// </summary>
        public Guid BranchId { get; set; }

        /// <summary>
        /// Gets or sets the branch entity associated with the sale.
        /// Indicates the branch where the sale was made.
        /// </summary>
        public Branch Branch { get; set; }

        /// <summary>
        /// Gets or sets the total monetary value of the sale.
        /// Includes the sum of all item prices and taxes.
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the sale was cancelled.
        /// </summary>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// Gets or sets the list of items included in the sale.
        /// Each item represents a product sold in the transaction.
        /// </summary>
        public List<SaleItem> SaleItems { get; set; } = new();

        public void Calculate()
        {
            TotalAmount = 0;
            SaleItems.ForEach(item =>
            {
                TotalAmount += (decimal)item.Total;
            });
        }
    }
}

