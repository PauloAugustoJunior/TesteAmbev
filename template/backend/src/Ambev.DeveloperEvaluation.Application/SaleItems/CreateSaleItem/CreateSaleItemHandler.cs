using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;

class CreateSaleItemHandler : IRequestHandler<CreateSaleItemCommand, CreateSaleItemResult>
{
    private readonly ISaleItemRepository _branchRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleItemHandler"/>.
    /// </summary>
    /// <param name="branchRepository">The branch repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public CreateSaleItemHandler(ISaleItemRepository branchRepository, IMapper mapper)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateSaleItemCommand request.
    /// </summary>
    /// <param name="command">The CreateSaleItem command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created branch details.</returns>
    public async Task<CreateSaleItemResult> Handle(CreateSaleItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleItemCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingSaleItem = await _branchRepository.GetByProductIdAndSaleIdAsync(command.ProductId, command.SaleId, cancellationToken);
        if (existingSaleItem != null)
            throw new InvalidOperationException($"SaleItem with product '{command.ProductId}' in a Sale '{command.SaleId}' already exists.");

        var branch = _mapper.Map<SaleItem>(command);

        var createdSaleItem = await _branchRepository.CreateAsync(branch, cancellationToken);

        return _mapper.Map<CreateSaleItemResult>(createdSaleItem);
    }
}
