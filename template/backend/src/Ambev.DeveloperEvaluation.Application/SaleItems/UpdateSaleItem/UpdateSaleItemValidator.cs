using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;

/// <summary>
/// Validator for <see cref="UpdateSaleItemCommand"/> that defines validation rules for branch creation.
/// </summary>
public class UpdateSaleItemCommandValidator : AbstractValidator<UpdateSaleItemCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateSaleItemCommandValidator"/> class
    /// with the defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Name: Required, must be between 3 and 100 characters.
    /// </remarks>
    public UpdateSaleItemCommandValidator()
    {
        RuleFor(branch => branch.Name)
            .NotNull()
                .WithMessage("SaleItem name must not be null.")
            .NotEmpty()
                .WithMessage("SaleItem name is required.")
            .Length(3, 100)
                .WithMessage("SaleItem name must be between 3 and 100 characters long.");
    }
}
