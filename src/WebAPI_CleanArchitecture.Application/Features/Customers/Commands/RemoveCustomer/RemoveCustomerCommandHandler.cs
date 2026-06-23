using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Customers;

namespace WebAPI_CleanArchitecture.Application.Features.Customers.Commands.RemoveCustomer
{
    internal sealed class RemoveCustomerCommandHandler(IUnitOfWork _unitOfWork)
        : ICommandHandler<RemoveCustomerCommand>
    {
        public async Task<Result<NoContentDto>> Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
        {
            // Find Customer by Id with including invoices
            var customer = await _unitOfWork.GetRepository<Customer>()
                .GetAll().Include(c => c.Invoices).FirstOrDefaultAsync(x => x.Id == request.CustomerId, cancellationToken);



            // check if customer is null return failed message with status code : 400
            if (customer is null)
                return Result<NoContentDto>.Fail(400, "Null.Error", $"The customer with Id {request.CustomerId} is not found!");



            // check if the customer have any invoices
            if (customer.Invoices.Count > 0)
                return Result<NoContentDto>.Fail(400, "Invalid.Error", $"The customer with id {request.CustomerId} has invoices.");



            // if customer is exist Delete him from database
            _unitOfWork.GetRepository<Customer>().Delete(customer);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Result<NoContentDto>.Success(200);
        }
    }
}
