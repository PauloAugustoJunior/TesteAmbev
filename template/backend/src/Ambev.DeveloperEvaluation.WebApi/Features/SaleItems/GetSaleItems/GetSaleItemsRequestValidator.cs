using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetSaleItems;

/// <summary>
/// Validator for GetSaleItemsRequest
/// </summary>
public class GetSaleItemsRequestValidator : AbstractValidator<GetSaleItemsRequest>
{
    /// <summary>
    /// Initializes validation rules for GetSaleItemsRequest
    /// </summary>
    public GetSaleItemsRequestValidator()
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
