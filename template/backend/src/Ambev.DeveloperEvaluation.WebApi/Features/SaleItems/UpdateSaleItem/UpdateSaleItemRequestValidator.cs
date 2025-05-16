using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.UpdateSaleItem;

/// <summary>
/// Validator for <see cref="UpdateSaleItemRequest"/> that defines validation rules for creating a branch.
/// </summary>
public class UpdateSaleItemRequestValidator : AbstractValidator<UpdateSaleItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateSaleItemRequestValidator"/> class.
    /// </summary>
    /// <remarks>
    /// Validation rules:
    /// - Name: Required and must be between 3 and 100 characters long.
    /// </remarks>
    public UpdateSaleItemRequestValidator()
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
