using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranches;

/// <summary>
/// Validator for GetBranchesQuery
/// </summary>
public class GetBranchesValidator : AbstractValidator<GetBranchesQuery>
{
    /// <summary>
    /// Initializes validation rules for GetBranchesQuery
    /// </summary>
    public GetBranchesValidator()
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
