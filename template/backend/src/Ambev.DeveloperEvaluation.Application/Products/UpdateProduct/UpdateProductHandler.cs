using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Handler for processing UpdateProductCommand requests
/// </summary>
public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateProductHandler"/>.
    /// </summary>
    /// <param name="productRepository">The branch repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the UpdateProductCommand request.
    /// </summary>
    /// <param name="command">The UpdateProduct command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created branch details.</returns>
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var productInDB = await _productRepository.GetByIdAsync(command.Id, cancellationToken);
        if (productInDB == null)
            throw new InvalidOperationException($"Product with ID '{command.Id}' not found.");

        if (command.Title != null)
        {
            var existingProductWithSameName = await _productRepository.GetByTitleAndBranchAsync(command.Title, productInDB.BranchId, cancellationToken);
            if (existingProductWithSameName != null && existingProductWithSameName.Id != productInDB.Id)
                throw new InvalidOperationException($"Another product with title '{command.Title}' already exists.");
        }

        productInDB.Title = command.Title ?? productInDB.Title;
        productInDB.Price = command.Price ?? productInDB.Price;
        productInDB.Description = command.Description ?? productInDB.Description;
        productInDB.Image = command.Image ?? productInDB.Image;
        productInDB.Category = command.Category ?? productInDB.Category;

        await _productRepository.UpdateAsync(productInDB, cancellationToken);

        return _mapper.Map<UpdateProductResult>(productInDB);
    }

}
