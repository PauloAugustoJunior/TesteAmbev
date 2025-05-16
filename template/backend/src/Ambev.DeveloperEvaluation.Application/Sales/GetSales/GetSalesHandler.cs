using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetSales;

/// <summary>
/// Handler for processing <see cref="GetSalesQuery"/> requests.
/// </summary>
public class GetSalesHandler : IRequestHandler<GetSalesQuery, List<GetSaleResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of <see cref="GetSalesHandler"/>.
    /// </summary>
    /// <param name="saleRepository">The branch repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public GetSalesHandler(
        ISaleRepository saleRepository,
        IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the <see cref="GetSalesQuery"/> request.
    /// </summary>
    /// <param name="request">The command containing the branch ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The branch details if found.</returns>
    public async Task<List<GetSaleResult>> Handle(GetSalesQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetSalesValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sales = await _saleRepository.GetAll(
            cancellationToken: cancellationToken
        );

        var mappedItems = _mapper.Map<List<GetSaleResult>>(sales);
        return mappedItems;
    }
}
