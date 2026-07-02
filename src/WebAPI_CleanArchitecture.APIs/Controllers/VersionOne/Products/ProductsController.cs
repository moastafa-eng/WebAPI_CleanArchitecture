using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI_CleanArchitecture.Application.Features.Customers.Commands.CreateCustomer;
using WebAPI_CleanArchitecture.Application.Features.Customers.Commands.RemoveCustomer;
using WebAPI_CleanArchitecture.Application.Features.Customers.Commands.UpdateCustomer;
using WebAPI_CleanArchitecture.Application.Features.Customers.Queries.GetAllCustomers;
using WebAPI_CleanArchitecture.Application.Features.Customers.Queries.GetCustomer;
using WebAPI_CleanArchitecture.Application.Features.Products.Commands.CreateProduct;
using WebAPI_CleanArchitecture.Application.Features.Products.Commands.RemoveProduct;
using WebAPI_CleanArchitecture.Application.Features.Products.Commands.UpdateProduct;
using WebAPI_CleanArchitecture.Application.Features.Products.Queries.GetAllProducts;
using WebAPI_CleanArchitecture.Application.Features.Products.Queries.GetProduct;
using WebAPI_CleanArchitecture.Domain.Entities.Customers.DTOs;
using WebAPI_CleanArchitecture.Domain.Entities.Products.DTOs;

namespace WebAPI_CleanArchitecture.APIs.Controllers.VersionOne.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ISender _sender) : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto request, CancellationToken cancellationToken = default)
        {
            // Send the Message(request) to the handler then return a response using ISender

            var response = await _sender.Send(new CreateProductCommand(request), cancellationToken);

            return CreateResult(response);

        }

        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetProduct(Guid productId, CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(new GetProductQuery(productId), cancellationToken);

            return CreateResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(new GetAllProductsQuery(), cancellationToken);

            return CreateResult(response);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto request, Guid productId, CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(new UpdateProductCommand(request, productId), cancellationToken);

            return CreateResult(response);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId, CancellationToken cancellationToken = default)
        {
            var response = await _sender.Send(new RemoveProductCommand(productId), cancellationToken);

            return CreateResult(response);
        }
    }
}
