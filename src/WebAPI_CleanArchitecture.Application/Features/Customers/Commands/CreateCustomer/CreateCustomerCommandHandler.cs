using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Commands;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Customers;

namespace WebAPI_CleanArchitecture.Application.Features.Customers.Commands.CreateCustomer
{
    internal sealed class CreateCustomerCommandHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        : ICommandHandler<CreateCustomerCommand, CustomerResponse>
    {
        public async Task<Result<CustomerResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            // create customer
            var customer = Customer.Create(request.Dto);


            // save it in database
            await _unitOfWork.GetRepository<Customer>().CreateAsync(customer, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            // do mapping
            var response = _mapper.Map<CustomerResponse>(customer);

            // return success with data and status code 201
            return Result<CustomerResponse>.Success(response, 201);
        }
    }
}
