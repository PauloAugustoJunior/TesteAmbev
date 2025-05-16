using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItem;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleHandler"/>.
    /// </summary>
    /// <param name="saleRepository">The branch repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper, IMediator mediator)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the CreateSaleCommand request.
    /// </summary>
    /// <param name="command">The CreateSale command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created branch details.</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var listProductToQuantity = await getAllProduct(command, cancellationToken);
        var branchIds = listProductToQuantity.Select(productToQuantity => productToQuantity.Product.BranchId).ToList();
        if (branchIds.Distinct().Count() > 1)
            throw new InvalidOperationException("Products from different branches are not allowed.");

        var sale = _mapper.Map<Sale>(command);
        sale.BranchId = branchIds.First();
        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);

        try
        {
            await saveSaleItems(listProductToQuantity, createdSale);
        }
        catch(Exception e)
        {
            await _saleRepository.DeleteAsync(createdSale.Id, cancellationToken);
        }

        createdSale.Calculate();
        await _saleRepository.UpdateAsync(createdSale, cancellationToken);

        var result = _mapper.Map<CreateSaleResult>(createdSale);
        return result;

        //await _saleRepository.AddAsync(sale);
        //await _unitOfWork.CommitAsync();

        //return new CreateSaleResult
        //{
        //    SaleId = sale.Id,
        //    UserId = sale.UserId,
        //    Date = sale.Date,
        //    Products = sale.Products.Select(p => new SaleProductResult
        //    {
        //        ProductId = p.ProductId,
        //        Quantity = p.Quantity
        //    }).ToList()
        //};
    }

    private async Task saveSaleItems(List<ProductToQuantity> listProductToQuantity, Sale createdSale)
    {
        var saleItems = new List<SaleItem>();
        foreach (var productToQuantity in listProductToQuantity)
        {
            var product = productToQuantity.Product;
            var saleItem = new SaleItem
            {
                Id = createdSale.Id,
                ProductId = product.Id,
                Quantity = productToQuantity.Quantity,
                UnitPrice = product.Price,
                Discount = 0,
                Total = 0,
                SaleId = createdSale.Id
            };
            saleItem.Calculate();
            saleItems.Add(saleItem);
            var createItemCommand = _mapper.Map<CreateSaleItemCommand>(saleItem);
            await _mediator.Send(createItemCommand, CancellationToken.None);
        }
    }

    private async Task<List<ProductToQuantity>> getAllProduct(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var products = new List<ProductToQuantity>();

        foreach (var p in command.Products)
        {
            var getProductQuery = new GetProductQuery(p.ProductId);
            var response = await _mediator.Send(getProductQuery, cancellationToken);
            var product = _mapper.Map<Product>(response);
            products.Add(new ProductToQuantity(product, p.Quantity));
        }

        return products;
    }
}
