using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem;

/// <summary>
/// Validator for <see cref="DeleteSaleItemCommand"/> that defines validation rules for branch creation.
/// </summary>
public class DeleteSaleItemCommandValidator : AbstractValidator<DeleteSaleItemCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteSaleItemCommandValidator"/> class
    /// with the defined validation rules.
    /// </summary>
    public DeleteSaleItemCommandValidator()
    {
        RuleFor(sale => sale)
        .Custom((sale, context) =>
        {
            if (sale.Id == null && sale.SaleId == null)
            {
                context.AddFailure("Either 'Id' or 'SaleId' must be provided.");
            }
        });
    }
}
