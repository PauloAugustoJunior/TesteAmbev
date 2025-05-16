using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

/// <summary>
/// Validator for <see cref="CreateSaleItemRequest"/> that defines validation rules for creating a sale item.
/// </summary>
public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleItemRequestValidator"/> class.
    /// </summary>
    public CreateSaleItemRequestValidator()
    {
        RuleFor(item => item.ProductId)
            .NotEqual(Guid.Empty)
            .WithMessage("ProductId is required and must be a valid GUID.");

        RuleFor(item => item.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than zero.");
    }
}
