﻿using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Command for creating a new branch.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a branch,
/// including its name. It implements <see cref="IRequest{TResponse}"/> to initiate the request
/// that returns a <see cref="CreateSaleResult"/>.
///
/// The data provided in this command is validated using the
/// <see cref="CreateSaleCommandValidator"/> which extends
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public Guid UserId { get; set; }
    public DateTimeOffset Date { get; set; }
    public List<SaleProductCommand> Products { get; set; } = new();

    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}

public class SaleProductCommand
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}