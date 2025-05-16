using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branchs.UpdateBranch;

/// <summary>
/// Validator for <see cref="UpdateBranchCommand"/> that defines validation rules for branch creation.
/// </summary>
public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateBranchCommandValidator"/> class
    /// with the defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Name: Required, must be between 3 and 100 characters.
    /// </remarks>
    public UpdateBranchCommandValidator()
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
