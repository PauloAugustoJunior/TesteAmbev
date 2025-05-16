using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for SaleItem entity operations.
/// </summary>
public interface ISaleItemRepository
{
    /// <summary>
    /// Creates a new SaleItem in the repository.
    /// </summary>
    /// <param name="SaleItem">The SaleItem to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created SaleItem.</returns>
    Task<SaleItem> CreateAsync(SaleItem SaleItem, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a SaleItem by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the SaleItem.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The SaleItem if found, null otherwise.</returns>
    Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<SaleItem>> GetAllBySaleIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<SaleItem?> GetByProductIdAndSaleIdAsync(Guid productId, Guid saleId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Deletes a SaleItem from the repository.
    /// </summary>
    /// <param name="id">The unique identifier of the SaleItem to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the SaleItem was deleted, false if not found.</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing SaleItem in the repository.
    /// </summary>
    /// <param name="SaleItem">The SaleItem entity with updated values.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UpdateAsync(SaleItem SaleItem, CancellationToken cancellationToken = default);

    Task<PaginatedList<SaleItem>> GetPaginatedListAsync(int pageNumber, int pageSize, string? order, CancellationToken cancellationToken);

}
