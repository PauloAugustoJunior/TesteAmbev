using System.Linq.Dynamic.Core;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of <see cref="ISaleItemRepository"/> using Entity Framework Core.
/// </summary>
public class SaleItemRepository : ISaleItemRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="SaleItemRepository"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    public SaleItemRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new SaleItem in the database.
    /// </summary>
    /// <param name="SaleItem">The SaleItem entity to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created SaleItem.</returns>
    public async Task<SaleItem> CreateAsync(SaleItem SaleItem, CancellationToken cancellationToken = default)
    {
        await _context.SaleItems.AddAsync(SaleItem, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return SaleItem;
    }

    /// <summary>
    /// Retrieves a SaleItem by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the SaleItem.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The SaleItem if found; otherwise, null.</returns>
    public async Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.SaleItems.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }
    
    public async Task<List<SaleItem>> GetAllBySaleIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.SaleItems
            .Where(o => o.SaleId == id)
            .ToListAsync(cancellationToken);
    }

    public async Task<SaleItem?> GetByProductIdAndSaleIdAsync(Guid productId, Guid saleId, CancellationToken cancellationToken = default)
    {
        return await _context.SaleItems
            .FirstOrDefaultAsync(o => o.ProductId == productId && o.SaleId == saleId, cancellationToken);
    }

    /// <summary>
    /// Deletes a SaleItem from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the SaleItem to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the SaleItem was deleted; false if not found.</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var SaleItem = await GetByIdAsync(id, cancellationToken);
        if (SaleItem == null)
            return false;

        _context.SaleItems.Remove(SaleItem);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Updates an existing SaleItem in the database.
    /// </summary>
    /// <param name="SaleItem">The SaleItem entity with updated values.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateAsync(SaleItem SaleItem, CancellationToken cancellationToken = default)
    {
        _context.SaleItems.Update(SaleItem);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves a paginated list of SaleItemes from the database with optional ordering.
    /// </summary>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="order">Optional ordering string (e.g., "name asc", "name desc").</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a paginated list of SaleItemes.</returns>
    public async Task<PaginatedList<SaleItem>> GetPaginatedListAsync(int pageNumber, int pageSize, string? order, CancellationToken cancellationToken)
    {
        var query = _context.SaleItems.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(order))
        {
            query = query.OrderBy(order);
        }
        else
        {
            query = query.OrderBy("Name");
        }
        return await PaginatedList<SaleItem>.CreateAsync(query, pageNumber, pageSize);
    }

}
