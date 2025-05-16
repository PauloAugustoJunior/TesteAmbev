using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranch;

/// <summary>
/// Validator for GetBranchRequest.
/// </summary>
public class GetBranchRequestValidator : AbstractValidator<GetBranchRequest>
{
    /// <summary>
    /// Initializes validation rules for GetBranchRequest.
    /// </summary>
    public GetBranchRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Please provide the branch ID.")
            .Must(x => x != Guid.Empty).WithMessage("The branch ID cannot be empty.");
    }
}
