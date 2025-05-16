using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem;

/// <summary>
/// Command for deleting an existing sale item.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for deleting a branch,
/// including its unique identifier and updated name. It implements <see cref="IRequest{TResponse}"/> 
/// to initiate the update request that returns a <see cref="DeleteSaleItemResult"/>.
///
/// The data provided in this command is validated using the
/// <see cref="DeleteSaleItemCommandValidator"/> which extends
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly
/// populated and follow the required rules.
/// </remarks>
public class DeleteSaleItemCommand : IRequest<DeleteSaleItemResult>
{
    public Guid? Id { get; set; }

    public Guid? SaleId { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new DeleteSaleItemCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
