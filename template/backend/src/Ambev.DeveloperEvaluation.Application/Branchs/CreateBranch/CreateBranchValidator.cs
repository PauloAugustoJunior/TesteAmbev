using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;

/// <summary>
/// Validator for <see cref="CreateBranchCommand"/> that defines validation rules for branch creation.
/// </summary>
public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateBranchCommandValidator"/> class
    /// with the defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Name: Required, must be between 3 and 100 characters.
    /// </remarks>
    public CreateBranchCommandValidator()
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
