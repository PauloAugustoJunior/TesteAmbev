using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;

/// <summary>
/// Command for creating a new branch.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a branch,
/// including its name. It implements <see cref="IRequest{TResponse}"/> to initiate the request
/// that returns a <see cref="CreateSaleItemResult"/>.
///
/// The data provided in this command is validated using the
/// <see cref="CreateSaleItemCommandValidator"/> which extends
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleItemCommand : IRequest<CreateSaleItemResult>
{
    /// <summary>
    /// Gets or sets the identifier of the product being sold.
    /// This foreign key refers to the Product entity, which contains detailed information about the product.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product being sold in this sale item.
    /// This field represents how many units of the product are included in the sale.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product.
    /// This field represents the price for a single unit of the product before applying any discounts.
    /// </summary>
    public double UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount applied to this particular sale item.
    /// The discount is a percentage that reduces the final price of the product.
    /// </summary>
    public double Discount { get; set; }

    /// <summary>
    /// Gets or sets the total price for this sale item after applying the quantity and any discounts.
    /// This value is calculated as: (UnitPrice * Quantity) - Discount.
    /// </summary>
    public double Total { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the sale to which this sale item belongs.
    /// This foreign key links this sale item to a specific sale record in the system.
    /// </summary>
    public Guid SaleId { get; set; }


    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleItemCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}