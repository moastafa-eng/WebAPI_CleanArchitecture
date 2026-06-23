using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Queries;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Customers;

namespace WebAPI_CleanArchitecture.Application.Features.Customers.Queries.GetAllCustomers
{
    internal sealed class GetAllCustomersQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        : IQueryHandler<GetAllCustomersQuery, CustomerResponseCollection>
    {
        public async Task<Result<CustomerResponseCollection>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _unitOfWork.GetRepository<Customer>
                ().GetAll().ProjectTo<CustomerResponse>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            //=================================================================================
            // Project to => Get only the requerd Fields from Database Based on PorductResponse
            // by other meaning Database return dto by self and this method is very fast
            //=================================================================================



            // mapping
            var response = new CustomerResponseCollection
            {
                Customers = customers.AsReadOnly()
            };


            return Result<CustomerResponseCollection>.Success(response, 200);
        }
    }
}
