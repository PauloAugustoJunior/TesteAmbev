using Ambev.DeveloperEvaluation.Application.Branchs.GetSales;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Controller for authentication operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of AuthController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public SalesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves a paginated list of branches, optionally ordered by specified criteria.
    /// </summary>
    /// <param name="page">The page number to retrieve (default is 1).</param>
    /// <param name="size">The number of items per page (default is 10).</param>
    /// <param name="order">Optional ordering criteria (e.g., "name asc" or "name desc").</param>
    /// <param name="context">The database context used to query branches.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A paginated list of branches.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<GetSaleResult>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSales(
    [FromQuery] GetSalesRequest request,
    CancellationToken cancellationToken = default)
    {
        var validator = new GetSalesRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var query = _mapper.Map<GetSalesQuery>(request);
        var results = await _mediator.Send(query, cancellationToken);

        var response = _mapper.Map<GetSalesResponse>(results);
        return Ok(response);
    }
    /// <summary>
    /// Retrieves a single branch by its ID (Guid).
    /// </summary>
    /// <param name="id">The unique identifier (Guid) of the branch.</param>
    /// <param name="context">The database context used to query the branch.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A single branch if found, otherwise a NotFound response.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetSaleResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSaleById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var request = new GetSaleRequest { Id = id };
        var validator = new GetSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetSaleQuery>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(_mapper.Map<GetSaleResponse>(response));
    }

    /// <summary>
    /// Creates a new branch
    /// </summary>
    /// <param name="request">The branch creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created branch details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateSaleCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);

        var response = _mapper.Map<CreateSaleResponse>(result);
        return Created(string.Empty, response);
    }

    [HttpPost("{id:guid}/cancel")]
    [ProducesResponseType(typeof(ApiResponseWithData<CancelSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CancelSale(Guid id, CancellationToken cancellationToken)
    {
        var request = new CancelSaleRequest { Id = id };
        var validator = new CancelSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CancelSaleCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);

        var response = _mapper.Map<CancelSaleResponse>(result);
        return Ok(response);
    }

    /// <summary>
    /// Deletes the name of an existing sale.
    /// </summary>
    /// <param name="id">The ID of the sale to update.</param>
    /// <param name="request">The deleted sale data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The deleted id sale details.</returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponseWithData<DeleteSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateSale(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteSaleCommand
        {
            Id = id
        };
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(_mapper.Map<DeleteSaleResponse>(result));
    }

}
