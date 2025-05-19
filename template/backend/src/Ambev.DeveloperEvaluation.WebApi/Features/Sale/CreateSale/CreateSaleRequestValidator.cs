using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for <see cref="CreateSaleRequest"/> that defines validation rules for creating a branch.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleRequestValidator"/> class.
    /// </summary>
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.UserId)
            .NotEqual(Guid.Empty)
            .WithMessage("UserId is required and must be a valid GUID.");

        RuleFor(sale => sale.Date)
            .NotEmpty()
            .WithMessage("Date is required.")
            .LessThanOrEqualTo(DateTimeOffset.UtcNow)
            .WithMessage("Date cannot be in the future.");

        RuleFor(sale => sale.Products)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Products list must not be null.")
            .NotEmpty().WithMessage("At least one product must be provided.")
            .Must(products => products.Select(p => p.ProductId).Distinct().Count() == products.Count)
            .WithMessage("Duplicate products are not allowed (ProductId must be unique).");

        RuleForEach(sale => sale.Products)
            .SetValidator(new CreateSaleItemRequestValidator());
    }
}

public class CreateSaleItemRequestValidator : AbstractValidator<SaleProductRequest>
{
    public CreateSaleItemRequestValidator()
    {
        RuleFor(p => p.ProductId)
            .NotEqual(Guid.Empty)
            .WithMessage("ProductId is required and must be a valid GUID.");

        RuleFor(p => p.Quantity)
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than zero.");
    }
}