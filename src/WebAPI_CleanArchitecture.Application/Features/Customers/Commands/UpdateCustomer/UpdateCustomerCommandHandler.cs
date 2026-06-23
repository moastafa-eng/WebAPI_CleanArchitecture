using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Customers;

namespace WebAPI_CleanArchitecture.Application.Features.Customers.Commands.UpdateCustomer
{
    internal sealed class UpdateCustomerCommandHandler(IUnitOfWork _unitOfWork)
        : ICommandHandler<UpdateCustomerCommand>
    {
        public async Task<Result<NoContentDto>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            // Get Customer by Id
            var customer = await _unitOfWork.GetRepository<Customer>().GetByIdAsync(request.Dto.CustomerId);



            // check if customer is null
            if (customer is null)
                return Result<NoContentDto>.Fail(404, "Null.Error", $"The customer with id {request.Dto.CustomerId} is not found!");




            // update row in database then save the changes
            _unitOfWork.GetRepository<Customer>().Update(customer);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Result<NoContentDto>.Success(204);

        }
    }
}
