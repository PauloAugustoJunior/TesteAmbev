using Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Handler for processing UpdateSaleCommand requests
/// </summary>
public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResult>
{
    private readonly ISaleRepository _branchRepository;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteSaleHandler"/>.
    /// </summary>
    /// <param name="branchRepository">The branch repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public DeleteSaleHandler(ISaleRepository branchRepository, IMapper mapper, IMediator mediator)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the UpdateSaleCommand request.
    /// </summary>
    /// <param name="command">The UpdateSale command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created branch details.</returns>
    public async Task<DeleteSaleResult> Handle(DeleteSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _branchRepository.GetByIdAsync(command.Id, cancellationToken);
        if (sale == null)
            throw new InvalidOperationException($"Sale with ID '{command.Id}' not found.");

        await _branchRepository.DeleteAsync(command.Id, cancellationToken);

        await _mediator.Send(new DeleteSaleItemCommand { Id = null, SaleId = command.Id });
        await _mediator.Publish(new DeleteSaleEvent(sale.Id));

        return _mapper.Map<DeleteSaleResult>(sale);
    }

}
