using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch;

/// <summary>
/// Handler for processing UpdateBranchCommand requests
/// </summary>
public class UpdateBranchHandler : IRequestHandler<UpdateBranchCommand, UpdateBranchResult>
{
    private readonly IBranchRepository _branchRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateBranchHandler"/>.
    /// </summary>
    /// <param name="branchRepository">The branch repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public UpdateBranchHandler(IBranchRepository branchRepository, IMapper mapper)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the UpdateBranchCommand request.
    /// </summary>
    /// <param name="command">The UpdateBranch command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created branch details.</returns>
    public async Task<UpdateBranchResult> Handle(UpdateBranchCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateBranchCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var branch = await _branchRepository.GetByIdAsync(command.Id, cancellationToken);
        if (branch == null)
            throw new InvalidOperationException($"Branch with ID '{command.Id}' not found.");

        var existingBranchWithSameName = await _branchRepository.GetByNameAsync(command.Name, cancellationToken);
        if (existingBranchWithSameName != null && existingBranchWithSameName.Id != branch.Id)
            throw new InvalidOperationException($"Another branch with name '{command.Name}' already exists.");

        branch.Name = command.Name;

        await _branchRepository.UpdateAsync(branch, cancellationToken);

        return _mapper.Map<UpdateBranchResult>(branch);
    }

}
