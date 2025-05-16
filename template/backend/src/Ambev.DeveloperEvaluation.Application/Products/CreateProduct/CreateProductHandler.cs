using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Handler for processing CreateProductCommand requests
/// </summary>
public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateProductHandler"/>.
    /// </summary>
    /// <param name="productRepository">The branch repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public CreateProductHandler(IProductRepository productRepository, IBranchRepository branchRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _branchRepository = branchRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateProductCommand request.
    /// </summary>
    /// <param name="command">The CreateProduct command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created branch details.</returns>
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingBranch = await _branchRepository.GetByIdAsync(command.BranchId, cancellationToken);
        if (existingBranch == null)
            throw new InvalidOperationException($"Branch with id {command.BranchId} not exists.");

        var existingEntity = await _productRepository.GetByTitleAndBranchAsync(command.Title, command.BranchId, cancellationToken);
        if (existingEntity != null)
            throw new InvalidOperationException($"Product with title '{command.Title}' in branchId {command.BranchId} already exists.");

        var entity = _mapper.Map<Product>(command);

        var createdProduct = await _productRepository.CreateAsync(entity, cancellationToken);

        return _mapper.Map<CreateProductResult>(createdProduct);
    }
}
