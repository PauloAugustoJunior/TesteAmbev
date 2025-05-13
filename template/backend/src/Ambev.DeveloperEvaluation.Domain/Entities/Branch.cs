using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a physical or operational branch of the organization,
    /// such as a store or office location.
    /// </summary>
    public class Branch : BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the branch.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the branch.
        /// Should be descriptive and distinguishable from other branches.
        /// </summary>
        public string Name { get; set; }
    }
}
