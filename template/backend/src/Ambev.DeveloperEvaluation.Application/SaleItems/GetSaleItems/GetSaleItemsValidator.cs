using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetSaleItems;

/// <summary>
/// Validator for GetSaleItemsQuery
/// </summary>
public class GetSaleItemsValidator : AbstractValidator<GetSaleItemsQuery>
{
    /// <summary>
    /// Initializes validation rules for GetSaleItemsQuery
    /// </summary>
    public GetSaleItemsValidator()
    {
        RuleFor(x => x.Size)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Size must be greater than or equal to 0")
            .LessThanOrEqualTo(100)
            .WithMessage("Size must be less than or equal to 100.");

        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Page must be greater than or equal to 0");
    }
}
