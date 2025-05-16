using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Product entity operations.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Creates a new Product in the repository.
    /// </summary>
    /// <param name="Product">The Product to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created Product.</returns>
    Task<Product> CreateAsync(Product Product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a Product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the Product.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The Product if found, null otherwise.</returns>
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a Product by its title.
    /// </summary>
    /// <param name="title">The title of the Product to search for.</param>
    /// <param name="branch">The id of the Branch to search for.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The Product if found, null otherwise.</returns>
    Task<Product?> GetByTitleAndBranchAsync(string title, Guid branchId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a Product from the repository.
    /// </summary>
    /// <param name="id">The unique identifier of the Product to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the Product was deleted, false if not found.</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing Product in the repository.
    /// </summary>
    /// <param name="Product">The Product entity with updated values.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UpdateAsync(Product Product, CancellationToken cancellationToken = default);

    Task<PaginatedList<Product>> GetPaginatedListAsync(int pageNumber, int pageSize, string? order, CancellationToken cancellationToken);

}
