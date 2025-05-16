using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Validator for <see cref="UpdateProductCommand"/> that defines validation rules for branch creation.
/// </summary>
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateProductCommandValidator"/> class
    /// with the defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Name: Required, must be between 3 and 100 characters.
    /// </remarks>
    public UpdateProductCommandValidator()
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
