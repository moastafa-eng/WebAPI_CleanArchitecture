using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Queries;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices;

namespace WebAPI_CleanArchitecture.Application.Features.Invoices.Queries.GetAllInvoices
{
    internal sealed class GetAllInvoicesQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        : IQueryHandler<GetAllInvoicesQuery, InvoiceResponseCollection>
    {
        public async Task<Result<InvoiceResponseCollection>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
        {
            // Get All Invoices
            var invoices = await _unitOfWork.GetRepository<Invoice>()
                .GetAll()
                .ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider) 
                .ToListAsync(cancellationToken);



            // convert from List<InvoiceResponse> to InvoiceResponeCollection.
            var response = new InvoiceResponseCollection
            {
                Invoices = invoices.AsReadOnly()
            };



            // return success message with data
            return Result<InvoiceResponseCollection>.Success(response, 200);
        }
    }
}
