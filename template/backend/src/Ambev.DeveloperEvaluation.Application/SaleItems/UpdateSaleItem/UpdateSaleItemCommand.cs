using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSaleItem;

/// <summary>
/// Command for updating an existing branch.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for updating a branch,
/// including its unique identifier and updated name. It implements <see cref="IRequest{TResponse}"/> 
/// to initiate the update request that returns a <see cref="UpdateSaleItemResult"/>.
///
/// The data provided in this command is validated using the
/// <see cref="UpdateSaleItemCommandValidator"/> which extends
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly
/// populated and follow the required rules.
/// </remarks>
public class UpdateSaleItemCommand : IRequest<UpdateSaleItemResult>
{
    /// <summary>
    /// Gets or sets the unique identifier of the branch to be updated.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the new name of the branch.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    public ValidationResultDetail Validate()
    {
        var validator = new UpdateSaleItemCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
