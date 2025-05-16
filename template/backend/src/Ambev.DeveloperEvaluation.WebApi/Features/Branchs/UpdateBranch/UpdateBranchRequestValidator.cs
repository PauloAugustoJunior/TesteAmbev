using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.UpdateBranch;

/// <summary>
/// Validator for <see cref="UpdateBranchRequest"/> that defines validation rules for creating a branch.
/// </summary>
public class UpdateBranchRequestValidator : AbstractValidator<UpdateBranchRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateBranchRequestValidator"/> class.
    /// </summary>
    /// <remarks>
    /// Validation rules:
    /// - Name: Required and must be between 3 and 100 characters long.
    /// </remarks>
    public UpdateBranchRequestValidator()
    {
        RuleFor(branch => branch.Name)
            .NotNull()
                .WithMessage("Branch name must not be null.")
            .NotEmpty()
                .WithMessage("Branch name is required.")
            .Length(3, 100)
                .WithMessage("Branch name must be between 3 and 100 characters long.");
    }
}
