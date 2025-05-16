using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;

/// <summary>
/// Validator for <see cref="CreateSaleItemCommand"/> that defines validation rules for branch creation.
/// </summary>
public class CreateSaleItemCommandValidator : AbstractValidator<CreateSaleItemCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleItemCommandValidator"/> class
    /// with the defined validation rules.
    /// </summary>
    public CreateSaleItemCommandValidator()
    {
        RuleFor(item => item.ProductId)
            .NotEqual(Guid.Empty)
            .WithMessage("ProductId is required and must be a valid GUID.");

        RuleFor(item => item.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than zero.")
            .LessThanOrEqualTo(20)
            .WithMessage("You cannot purchase more than 20 units of a product.");

        RuleFor(item => item.UnitPrice)
            .GreaterThan(0)
            .WithMessage("UnitPrice must be greater than zero.");

        RuleFor(item => item.Discount)
            .InclusiveBetween(0, 0.20)
            .WithMessage("Discount must be 0%, 10% or 20% only.")
            .Must((command, discount) =>
            {
                if (command.Quantity < 4 && discount > 0)
                    return false;
                if (command.Quantity >= 4 && command.Quantity < 10 && discount != 0.10)
                    return false;
                if (command.Quantity >= 10 && command.Quantity <= 20 && discount != 0.20)
                    return false;
                return true;
            })
            .WithMessage("Discount is not allowed or incorrect for the given quantity.");

        RuleFor(item => item.Total)
            .Must((item, total) =>
            {
                var expectedTotal = item.UnitPrice * item.Quantity * (1 - item.Discount);
                return Math.Abs(expectedTotal - item.Total) < 0.01;
            })
            .WithMessage("Total must match (UnitPrice * Quantity) - Discount.");
    }
}
