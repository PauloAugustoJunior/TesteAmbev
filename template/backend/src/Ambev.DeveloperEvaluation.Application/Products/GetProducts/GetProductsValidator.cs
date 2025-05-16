using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Validator for GetProductsQuery
/// </summary>
public class GetProductsValidator : AbstractValidator<GetProductsQuery>
{
    /// <summary>
    /// Initializes validation rules for GetProductsQuery
    /// </summary>
    public GetProductsValidator()
    {
        RuleFor(x => x.Size)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Size must be greater than or equal to 0")
            .LessThanOrEqualTo(100)
            .WithMessage("O parâmetro 'Size' deve ser menor ou igual a 100.");

        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Page must be greater than or equal to 0");
    }
}
