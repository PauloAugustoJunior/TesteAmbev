using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Validator for <see cref="CancelSaleCommand"/> that defines validation rules for branch creation.
/// </summary>
public class CancelSaleCommandValidator : AbstractValidator<CancelSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CancelSaleCommandValidator"/> class
    /// with the defined validation rules.
    /// </summary>
    public CancelSaleCommandValidator()
    {
        RuleFor(sale => sale.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("SaleId is required and must be a valid GUID.");
    }
}
