using Ambev.DeveloperEvaluation.Application.Branchs.GetSaleItems;
using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetSaleItems;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.GetSaleItem;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.UpdateSaleItem;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems;

/// <summary>
/// Controller for authentication operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SaleItemsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of AuthController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public SaleItemsController(IMediator mediator, IMapper mapper)
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
    //[HttpGet]
    //[ProducesResponseType(typeof(GetSaleItemsResponse), StatusCodes.Status200OK)]
    //public async Task<IActionResult> GetSaleItems(
    //[FromQuery] GetSaleItemsRequest request,
    //CancellationToken cancellationToken = default)
    //{
    //    var validator = new GetSaleItemsRequestValidator();
    //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    //    if (!validationResult.IsValid)
    //        return BadRequest(validationResult.Errors);

    //    var query = _mapper.Map<GetSaleItemsQuery>(request);
    //    var results = await _mediator.Send(query, cancellationToken);

    //    var response = _mapper.Map<GetSaleItemsResponse>(results);
    //    return Ok(response);
    //}
    ///// <summary>
    ///// Retrieves a single branch by its ID (Guid).
    ///// </summary>
    ///// <param name="id">The unique identifier (Guid) of the branch.</param>
    ///// <param name="context">The database context used to query the branch.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>A single branch if found, otherwise a NotFound response.</returns>
    //[HttpGet("{id}")]
    //[ProducesResponseType(typeof(GetSaleItemResponse), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> GetSaleItemById(
    //    Guid id,
    //    CancellationToken cancellationToken = default)
    //{
    //    var request = new GetSaleItemRequest { Id = id };
    //    var validator = new GetSaleItemRequestValidator();
    //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    //    if (!validationResult.IsValid)
    //        return BadRequest(validationResult.Errors);

    //    var command = _mapper.Map<GetSaleItemQuery>(request.Id);
    //    var response = await _mediator.Send(command, cancellationToken);

    //    return Ok(_mapper.Map<GetSaleItemResponse>(response));
    //}

    ///// <summary>
    ///// Creates a new branch
    ///// </summary>
    ///// <param name="request">The branch creation request</param>
    ///// <param name="cancellationToken">Cancellation token</param>
    ///// <returns>The created branch details</returns>
    //[HttpPost]
    //[ProducesResponseType(typeof(ApiResponseWithData<CreateSaleItemResponse>), StatusCodes.Status201Created)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    //public async Task<IActionResult> CreateSaleItem([FromBody] CreateSaleItemRequest request, CancellationToken cancellationToken)
    //{
    //    var validator = new CreateSaleItemRequestValidator();
    //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    //    if (!validationResult.IsValid)
    //        return BadRequest(validationResult.Errors);

    //    var command = _mapper.Map<CreateSaleItemCommand>(request);
    //    var response = await _mediator.Send(command, cancellationToken);

    //    return Created(string.Empty, new ApiResponseWithData<CreateSaleItemResponse>
    //    {
    //        Success = true,
    //        Message = "SaleItem created successfully",
    //        Data = _mapper.Map<CreateSaleItemResponse>(response)
    //    });
    //}

    ///// <summary>
    ///// Updates the name of an existing branch.
    ///// </summary>
    ///// <param name="id">The ID of the branch to update.</param>
    ///// <param name="request">The updated branch data.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>The updated branch details.</returns>
    //[HttpPut("{id:guid}")]
    //[ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleItemResponse>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> UpdateSaleItem(Guid id, [FromBody] UpdateSaleItemRequest request, CancellationToken cancellationToken)
    //{
    //    var command = _mapper.Map<UpdateSaleItemCommand>(request);
    //    command.Id = id;

    //    var validator = new UpdateSaleItemRequestValidator();
    //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    //    var result = await _mediator.Send(command, cancellationToken);
    //    return Ok(_mapper.Map<UpdateSaleItemResponse>(result));
    //}

}
