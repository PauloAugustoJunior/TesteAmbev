using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranches;

/// <summary>
/// Validator for GetBranchesRequest
/// </summary>
public class GetBranchesRequestValidator : AbstractValidator<GetBranchesRequest>
{
    /// <summary>
    /// Initializes validation rules for GetBranchesRequest
    /// </summary>
    public GetBranchesRequestValidator()
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
