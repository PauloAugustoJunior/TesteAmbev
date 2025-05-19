using System.Linq.Dynamic.Core;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of <see cref="ISaleRepository"/> using Entity Framework Core.
/// </summary>
public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="SaleRepository"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new Sale in the database.
    /// </summary>
    /// <param name="Sale">The Sale entity to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created Sale.</returns>
    public async Task<Sale> CreateAsync(Sale Sale, CancellationToken cancellationToken = default)
    {
        await _context.Sales.AddAsync(Sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Sale;
    }

    /// <summary>
    /// Retrieves a Sale by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the Sale.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The Sale if found; otherwise, null.</returns>
    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Sales
            .Include(s => s.SaleItems)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Deletes a Sale from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the Sale to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the Sale was deleted; false if not found.</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var Sale = await GetByIdAsync(id, cancellationToken);
        if (Sale == null)
            return false;

        _context.Sales.Remove(Sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Updates an existing Sale in the database.
    /// </summary>
    /// <param name="Sale">The Sale entity with updated values.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateAsync(Sale Sale, CancellationToken cancellationToken = default)
    {
        foreach (var item in Sale.SaleItems)
        {
            var localItem = _context.Set<SaleItem>().Local.FirstOrDefault(e => e.Id == item.Id);
            if (localItem != null)
            {
                _context.Entry(localItem).State = EntityState.Detached;
            }
        }

        _context.Sales.Update(Sale);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves a paginated list of Salees from the database with optional ordering.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a paginated list of Salees.</returns>
    public async Task<List<Sale>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Sales.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<bool> CancelAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;

        sale.IsCancelled = true;
        _context.Sales.Update(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<PaginatedList<Sale>> GetPaginatedListAsync(int pageNumber, int pageSize, string? order, CancellationToken cancellationToken)
    {
        var query = _context.Sales.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(order))
        {
            query = query.OrderBy(order);
        }
        else
        {
            query = query.OrderBy("SaleDate");
        }
        return await PaginatedList<Sale>.CreateAsync(query, pageNumber, pageSize);
    }

}
