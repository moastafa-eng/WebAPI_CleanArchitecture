using AutoMapper;
using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Queries;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Customers;

namespace WebAPI_CleanArchitecture.Application.Features.Customers.Queries.GetCustomer
{
    internal sealed class GetCustomerQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        : IQueryHandler<GetCustomerQuery, CustomerResponse>
    {
        public async Task<Result<CustomerResponse>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            // Get Customer by id
            var customer = await _unitOfWork.GetRepository<Customer>().GetByIdAsync(request.CustomerId);



            // check if customer is null
            if (customer is null)
                return Result<CustomerResponse>.Failed(404, "Null.Error", $"The customer with id {request.CustomerId} is not found!");



            // do the mapping
            var response = _mapper.Map<CustomerResponse>(customer);

            return Result<CustomerResponse>.Success(response, 200);
            
        }
    }
}
