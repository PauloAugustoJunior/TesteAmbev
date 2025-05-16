using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for <see cref="CreateProductRequest"/> that defines validation rules for creating a product.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(product => product.Title)
            .NotNull().WithMessage("Product title must not be null.")
            .NotEmpty().WithMessage("Product title is required.")
            .Length(3, 100).WithMessage("Product title must be between 3 and 100 characters long.");

        RuleFor(product => product.Price)
            .GreaterThan(0).WithMessage("Product price must be greater than zero.");

        RuleFor(product => product.Image)
            .NotNull().WithMessage("Product image must not be null.")
            .NotEmpty().WithMessage("Product image is required.");

        RuleFor(product => product.BranchId)
            .NotEqual(Guid.Empty).WithMessage("A valid BranchId is required.");

        RuleFor(product => product.Description)
            .MaximumLength(500).WithMessage("Product description must not exceed 500 characters.")
            .When(p => !string.IsNullOrWhiteSpace(p.Description));
    }
}