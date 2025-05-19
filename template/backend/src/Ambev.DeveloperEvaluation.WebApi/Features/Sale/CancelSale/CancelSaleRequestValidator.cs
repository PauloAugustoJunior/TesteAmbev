using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

public class CancelSaleRequestValidator : AbstractValidator<CancelSaleRequest>
{
    public CancelSaleRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Please provide the sale ID.")
            .Must(x => x != Guid.Empty).WithMessage("The sale ID cannot be empty.");
    }
}
