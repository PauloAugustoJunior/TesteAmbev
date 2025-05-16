using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;
using Ambev.DeveloperEvaluation.Application.Branchs.GetBranches;
using Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranches;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.UpdateBranch;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs;

/// <summary>
/// Controller for authentication operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BranchsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of AuthController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public BranchsController(IMediator mediator, IMapper mapper)
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
    [ProducesResponseType(typeof(GetBranchesResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBranches(
    [FromQuery] GetBranchesRequest request,
    CancellationToken cancellationToken = default)
    {
        var validator = new GetBranchesRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var query = _mapper.Map<GetBranchesQuery>(request);
        var results = await _mediator.Send(query, cancellationToken);

        var response = _mapper.Map<GetBranchesResponse>(results);
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
    [ProducesResponseType(typeof(GetBranchResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBranchById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var request = new GetBranchRequest { Id = id };
        var validator = new GetBranchRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetBranchQuery>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(_mapper.Map<GetBranchResponse>(response));
    }

    /// <summary>
    /// Creates a new branch
    /// </summary>
    /// <param name="request">The branch creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created branch details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateBranchResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBranch([FromBody] CreateBranchRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateBranchRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateBranchCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateBranchResponse>
        {
            Success = true,
            Message = "Branch created successfully",
            Data = _mapper.Map<CreateBranchResponse>(response)
        });
    }

    /// <summary>
    /// Updates the name of an existing branch.
    /// </summary>
    /// <param name="id">The ID of the branch to update.</param>
    /// <param name="request">The updated branch data.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated branch details.</returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateBranchResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBranch(Guid id, [FromBody] UpdateBranchRequest request, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateBranchCommand>(request);
        command.Id = id;

        var validator = new UpdateBranchRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        var result = await _mediator.Send(command, cancellationToken);
        return Ok(_mapper.Map<UpdateBranchResponse>(result));
    }

}
