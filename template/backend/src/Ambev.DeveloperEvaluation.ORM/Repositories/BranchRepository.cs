using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of <see cref="IBranchRepository"/> using Entity Framework Core.
/// </summary>
public class BranchRepository : IBranchRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="BranchRepository"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    public BranchRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new branch in the database.
    /// </summary>
    /// <param name="branch">The branch entity to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created branch.</returns>
    public async Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken = default)
    {
        await _context.Branchs.AddAsync(branch, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return branch;
    }

    /// <summary>
    /// Retrieves a branch by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the branch.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The branch if found; otherwise, null.</returns>
    public async Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Branchs.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves a branch by its name.
    /// </summary>
    /// <param name="name">The name of the branch to search for.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The branch if found; otherwise, null.</returns>
    public async Task<Branch?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _context.Branchs
            .FirstOrDefaultAsync(u => u.Name == name, cancellationToken);
    }

    /// <summary>
    /// Deletes a branch from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the branch to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the branch was deleted; false if not found.</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var branch = await GetByIdAsync(id, cancellationToken);
        if (branch == null)
            return false;

        _context.Branchs.Remove(branch);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Updates an existing branch in the database.
    /// </summary>
    /// <param name="branch">The branch entity with updated values.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateAsync(Branch branch, CancellationToken cancellationToken = default)
    {
        _context.Branchs.Update(branch);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves a paginated list of branches from the database with optional ordering.
    /// </summary>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="order">Optional ordering string (e.g., "name asc", "name desc").</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a paginated list of branches.</returns>
    public async Task<PaginatedList<Branch>> GetPaginatedListAsync(int pageNumber, int pageSize, string? order, CancellationToken cancellationToken)
    {
        var query = _context.Branchs.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(order))
        {
            query = query.OrderBy(order);
        }
        else
        {
            query = query.OrderBy("Name");
        }
        return await PaginatedList<Branch>.CreateAsync(query, pageNumber, pageSize);
    }

}
