using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

/// <summary>
/// Validator for <see cref="UpdateProductRequest"/> that defines validation rules for creating a branch.
/// </summary>
public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateProductRequestValidator"/> class.
    /// </summary>
    /// <remarks>
    /// Validation rules:
    /// - Name: Required and must be between 3 and 100 characters long.
    /// </remarks>
    public UpdateProductRequestValidator()
    {
        RuleFor(product => product.Title)
            .NotEmpty().WithMessage("Product title is required.")
            .Length(3, 100).WithMessage("Product title must be between 3 and 100 characters long.")
            .When(product => product.Title != null);

        RuleFor(product => product.Price)
            .GreaterThan(0).WithMessage("Product price must be greater than zero.")
            .When(product => product.Price != null);

        RuleFor(product => product.Image)
            .NotEmpty().WithMessage("Product image is required.")
            .When(product => product.Image != null);

        RuleFor(product => product.Description)
            .MaximumLength(500).WithMessage("Product description must not exceed 500 characters.")
            .When(p => !string.IsNullOrWhiteSpace(p.Description));
    }
}
