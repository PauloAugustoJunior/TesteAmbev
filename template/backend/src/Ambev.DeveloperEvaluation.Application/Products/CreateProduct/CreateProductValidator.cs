using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for <see cref="CreateProductCommand"/> that defines validation rules for branch creation.
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateProductCommandValidator"/> class,
    /// configuring validation rules for product creation.
    /// </summary>
    /// <remarks>
    /// The constructor defines the following validation rules:
    /// - <c>Title</c>: Required, not empty, length between 3 and 100 characters.
    /// - <c>Price</c>: Must be greater than zero.
    /// - <c>Image</c>: Required, not null or empty.
    /// - <c>BranchId</c>: Must be a valid, non-empty GUID.
    /// - <c>Description</c>: Optional, but limited to 500 characters if provided.
    /// </remarks>
    public CreateProductCommandValidator()
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
