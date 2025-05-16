using System.Linq.Dynamic.Core;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of <see cref="IProductRepository"/> using Entity Framework Core.
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductRepository"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    public ProductRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new Product in the database.
    /// </summary>
    /// <param name="Product">The Product entity to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created Product.</returns>
    public async Task<Product> CreateAsync(Product Product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(Product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Product;
    }

    /// <summary>
    /// Retrieves a Product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the Product.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The Product if found; otherwise, null.</returns>
    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves a Product by its title.
    /// </summary>
    /// <param name="title">The title of the Product to search for.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The Product if found; otherwise, null.</returns>
    public async Task<Product?> GetByTitleAndBranchAsync(string title, Guid branchId, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .FirstOrDefaultAsync(u => u.Title == title && u.BranchId == branchId, cancellationToken);
    }

    /// <summary>
    /// Deletes a Product from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the Product to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the Product was deleted; false if not found.</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var Product = await GetByIdAsync(id, cancellationToken);
        if (Product == null)
            return false;

        _context.Products.Remove(Product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Updates an existing Product in the database.
    /// </summary>
    /// <param name="Product">The Product entity with updated values.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateAsync(Product Product, CancellationToken cancellationToken = default)
    {
        _context.Products.Update(Product);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves a paginated list of Productes from the database with optional ordering.
    /// </summary>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="order">Optional ordering string (e.g., "name asc", "name desc").</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation, containing a paginated list of Productes.</returns>
    public async Task<PaginatedList<Product>> GetPaginatedListAsync(int pageNumber, int pageSize, string? order, CancellationToken cancellationToken)
    {
        var query = _context.Products.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(order))
        {
            query = query.OrderBy(order);
        }
        else
        {
            query = query.OrderBy("Title");
        }
        return await PaginatedList<Product>.CreateAsync(query, pageNumber, pageSize);
    }

}
