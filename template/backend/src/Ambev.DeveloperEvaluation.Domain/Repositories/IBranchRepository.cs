using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Branch entity operations.
/// </summary>
public interface IBranchRepository
{
    /// <summary>
    /// Creates a new branch in the repository.
    /// </summary>
    /// <param name="branch">The branch to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created branch.</returns>
    Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a branch by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the branch.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The branch if found, null otherwise.</returns>
    Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a branch by its name.
    /// </summary>
    /// <param name="name">The name of the branch to search for.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The branch if found, null otherwise.</returns>
    Task<Branch?> GetByNameAsync(string name, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a branch from the repository.
    /// </summary>
    /// <param name="id">The unique identifier of the branch to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the branch was deleted, false if not found.</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing branch in the repository.
    /// </summary>
    /// <param name="branch">The branch entity with updated values.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UpdateAsync(Branch branch, CancellationToken cancellationToken = default);

    Task<PaginatedList<Branch>> GetPaginatedListAsync(int pageNumber, int pageSize, string? order, CancellationToken cancellationToken);

}
