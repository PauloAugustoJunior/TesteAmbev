using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

/// <summary>
/// Validator for <see cref="DeleteSaleRequest"/> that defines validation rules for creating a branch.
/// </summary>
public class DeleteSaleRequestValidator : AbstractValidator<DeleteSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteSaleRequestValidator"/> class.
    /// </summary>
    public DeleteSaleRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Please provide the sale ID.")
            .Must(x => x != Guid.Empty).WithMessage("The sale ID cannot be empty.");
    }
}
