using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

/// <summary>
/// Validator for GetProductsRequest
/// </summary>
public class GetProductsRequestValidator : AbstractValidator<GetProductsRequest>
{
    /// <summary>
    /// Initializes validation rules for GetProductsRequest
    /// </summary>
    public GetProductsRequestValidator()
    {
        RuleFor(x => x.Size)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Size must be greater than or equal to 0")
            .LessThanOrEqualTo(100)
            .WithMessage("O par�metro 'Size' deve ser menor ou igual a 100.");

        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Page must be greater than or equal to 0");
    }
}
