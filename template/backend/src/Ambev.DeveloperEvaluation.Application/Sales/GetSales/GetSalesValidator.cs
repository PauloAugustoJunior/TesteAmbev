using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetSales;

/// <summary>
/// Validator for GetSalesQuery
/// </summary>
public class GetSalesValidator : AbstractValidator<GetSalesQuery>
{
    /// <summary>
    /// Initializes validation rules for GetSalesQuery
    /// </summary>
    public GetSalesValidator()
    {
        RuleFor(x => x.Size)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Size must be greater than or equal to 0")
            .LessThanOrEqualTo(100)
            .WithMessage("The 'Size' parameter must be less than or equal to 100.");

        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Page must be greater than or equal to 0");
    }
}
