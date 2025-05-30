using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem;

/// <summary>
/// Validator for GetSaleItemQuery
/// </summary>
public class GetSaleItemValidator : AbstractValidator<GetSaleItemQuery>
{
    /// <summary>
    /// Initializes validation rules for GetSaleItemQuery
    /// </summary>
    public GetSaleItemValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Please provide the SaleItem ID.")
            .Must(x => x != Guid.Empty).WithMessage("The SaleItem ID cannot be empty.");
    }
}
