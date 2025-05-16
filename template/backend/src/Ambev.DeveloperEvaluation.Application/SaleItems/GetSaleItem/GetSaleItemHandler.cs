using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;

/// <summary>
/// Handler for processing <see cref="GetSaleItemQuery"/> requests.
/// </summary>
public class GetSaleItemHandler : IRequestHandler<GetSaleItemQuery, GetSaleItemResult>
{
    private readonly ISaleItemRepository _branchRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of <see cref="GetSaleItemHandler"/>.
    /// </summary>
    /// <param name="branchRepository">The branch repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public GetSaleItemHandler(
        ISaleItemRepository branchRepository,
        IMapper mapper)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the <see cref="GetSaleItemQuery"/> request.
    /// </summary>
    /// <param name="request">The command containing the branch ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The branch details if found.</returns>
    public async Task<GetSaleItemResult> Handle(GetSaleItemQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetSaleItemValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var branch = await _branchRepository.GetByIdAsync(request.Id, cancellationToken);
        if (branch == null)
            throw new KeyNotFoundException($"SaleItem with ID {request.Id} not found");

        return _mapper.Map<GetSaleItemResult>(branch);
    }
}
