using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

/// <summary>
/// Validator for GetBranchQuery
/// </summary>
public class GetBranchValidator : AbstractValidator<GetBranchQuery>
{
    /// <summary>
    /// Initializes validation rules for GetBranchQuery
    /// </summary>
    public GetBranchValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Please provide the branch ID.")
            .Must(x => x != Guid.Empty).WithMessage("The branch ID cannot be empty.");
    }
}
