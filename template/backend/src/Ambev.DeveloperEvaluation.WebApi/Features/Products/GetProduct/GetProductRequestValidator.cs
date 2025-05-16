using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// Validator for GetProductRequest.
/// </summary>
public class GetProductRequestValidator : AbstractValidator<GetProductRequest>
{
    /// <summary>
    /// Initializes validation rules for GetProductRequest.
    /// </summary>
    public GetProductRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Please provide the branch ID.")
            .Must(x => x != Guid.Empty).WithMessage("The branch ID cannot be empty.");
    }
}
