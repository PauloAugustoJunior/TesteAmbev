using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem;

/// <summary>
/// Handler for processing DeleteSaleItemCommand requests
/// </summary>
public class DeleteSaleItemHandler : IRequestHandler<DeleteSaleItemCommand, DeleteSaleItemResult>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteSaleItemHandler"/>.
    /// </summary>
    /// <param name="saleItemRepository">The branch repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public DeleteSaleItemHandler(ISaleItemRepository saleItemRepository, IMapper mapper)
    {
        _saleItemRepository = saleItemRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the DeleteSaleItemCommand request.
    /// </summary>
    /// <param name="command">The DeleteSaleItem command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created branch details.</returns>
    public async Task<DeleteSaleItemResult> Handle(DeleteSaleItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleItemCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = new DeleteSaleItemResult();

        if (command.Id != null)
        {
            var saleItem = await _saleItemRepository.GetByIdAsync((Guid)command.Id, cancellationToken);
            if (saleItem == null)
                throw new InvalidOperationException($"SaleItem with ID '{command.Id}' not found.");
            await _saleItemRepository.DeleteAsync(saleItem.Id, cancellationToken);
            result.ListId.Add(saleItem.Id);
        }
        else
        {
            var saleItems = await _saleItemRepository.GetAllBySaleIdAsync((Guid)command.SaleId, cancellationToken);
            if (saleItems == null)
                throw new InvalidOperationException($"SaleItem with SaleId '{command.Id}' not found.");
            foreach (var saleItem in saleItems)
            {
                await _saleItemRepository.DeleteAsync(saleItem.Id, cancellationToken);
                result.ListId.Add(saleItem.Id);
            }
        }

        return result;
    }

}
