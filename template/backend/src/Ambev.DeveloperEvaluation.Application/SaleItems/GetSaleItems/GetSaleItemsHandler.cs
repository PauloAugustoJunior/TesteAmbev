using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetSaleItems;

/// <summary>
/// Handler for processing <see cref="GetSaleItemsQuery"/> requests.
/// </summary>
public class GetSaleItemsHandler : IRequestHandler<GetSaleItemsQuery, GetSaleItemsResult>
{
    private readonly IBranchRepository _branchRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of <see cref="GetSaleItemsHandler"/>.
    /// </summary>
    /// <param name="branchRepository">The branch repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public GetSaleItemsHandler(
        IBranchRepository branchRepository,
        IMapper mapper)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the <see cref="GetSaleItemsQuery"/> request.
    /// </summary>
    /// <param name="request">The command containing the branch ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The branch details if found.</returns>
    public async Task<GetSaleItemsResult> Handle(GetSaleItemsQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetSaleItemsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var branches = await _branchRepository.GetPaginatedListAsync(
            pageNumber: request.Page,
            pageSize: request.Size,
            order: request.Order,
            cancellationToken: cancellationToken
        );

        var mappedItems = _mapper.Map<List<GetBranchResult>>(branches);

        return new GetSaleItemsResult(
            mappedItems,
            branches.TotalCount,
            branches.CurrentPage,
            branches.TotalPages
        );
    }
}
