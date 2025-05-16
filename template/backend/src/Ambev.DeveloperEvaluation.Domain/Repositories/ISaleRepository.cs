using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Sale entity operations.
/// </summary>
public interface ISaleRepository
{
    /// <summary>
    /// Creates a new Sale in the repository.
    /// </summary>
    /// <param name="Sale">The Sale to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created Sale.</returns>
    Task<Sale> CreateAsync(Sale Sale, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a Sale by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the Sale.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The Sale if found, null otherwise.</returns>
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a Sale from the repository.
    /// </summary>
    /// <param name="id">The unique identifier of the Sale to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the Sale was deleted, false if not found.</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing Sale in the repository.
    /// </summary>
    /// <param name="Sale">The Sale entity with updated values.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UpdateAsync(Sale Sale, CancellationToken cancellationToken = default);

    Task<List<Sale>> GetAll(CancellationToken cancellationToken);

}
