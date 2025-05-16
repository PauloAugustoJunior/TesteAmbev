using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Validator for <see cref="DeleteSaleCommand"/> that defines validation rules for branch creation.
/// </summary>
public class DeleteSaleCommandValidator : AbstractValidator<DeleteSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteSaleCommandValidator"/> class
    /// with the defined validation rules.
    /// </summary>
    public DeleteSaleCommandValidator()
    {
        RuleFor(sale => sale.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("ProductId is required and must be a valid GUID.");
    }
}
