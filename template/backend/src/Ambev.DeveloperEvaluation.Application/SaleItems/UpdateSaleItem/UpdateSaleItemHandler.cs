using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;

/// <summary>
/// Handler for processing UpdateSaleItemCommand requests
/// </summary>
public class UpdateSaleItemHandler : IRequestHandler<UpdateSaleItemCommand, UpdateSaleItemResult>
{
    private readonly ISaleItemRepository _branchRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateSaleItemHandler"/>.
    /// </summary>
    /// <param name="branchRepository">The branch repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public UpdateSaleItemHandler(ISaleItemRepository branchRepository, IMapper mapper)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the UpdateSaleItemCommand request.
    /// </summary>
    /// <param name="command">The UpdateSaleItem command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created branch details.</returns>
    public async Task<UpdateSaleItemResult> Handle(UpdateSaleItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleItemCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var branch = await _branchRepository.GetByIdAsync(command.Id, cancellationToken);
        if (branch == null)
            throw new InvalidOperationException($"SaleItem with ID '{command.Id}' not found.");

        //var existingSaleItemWithSameName = await _branchRepository.GetByNameAsync(command.Name, cancellationToken);
        //if (existingSaleItemWithSameName != null && existingSaleItemWithSameName.Id != branch.Id)
        //    throw new InvalidOperationException($"Another branch with name '{command.Name}' already exists.");
        //branch.Name = command.Name;

        await _branchRepository.UpdateAsync(branch, cancellationToken);

        return _mapper.Map<UpdateSaleItemResult>(branch);
    }

}
