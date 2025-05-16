using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Validator for <see cref="DeleteSaleRequest"/> that defines validation rules for creating a branch.
/// </summary>
public class DeleteSaleRequestValidator : AbstractValidator<DeleteSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteSaleRequestValidator"/> class.
    /// </summary>
    /// <remarks>
    /// Validation rules:
    /// - Name: Required and must be between 3 and 100 characters long.
    /// </remarks>
    public DeleteSaleRequestValidator()
    {
        RuleFor(branch => branch.Name)
            .NotNull()
                .WithMessage("Sale name must not be null.")
            .NotEmpty()
                .WithMessage("Sale name is required.")
            .Length(3, 100)
                .WithMessage("Sale name must be between 3 and 100 characters long.");
    }
}
