using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WebAPI_CleanArchitecture.Application.Abstraction.Messaging.Queries;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices;

namespace WebAPI_CleanArchitecture.Application.Features.Invoices.Queries.GetInvoice
{
    internal sealed class GetInvoiceQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        : IQueryHandler<GetInvoiceQuery, InvoiceResponse>
    {
        public async Task<Result<InvoiceResponse>> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
        {
            // Get Invocie By Id And Include InvoiceItems with Mapping.
            var response = await _unitOfWork.GetRepository<Invoice>()
                .GetAll()
                .Include(i => i.PurchasedProducts)
                .ProjectTo<InvoiceResponse>(_mapper.ConfigurationProvider) // Allow Mapping
                .FirstOrDefaultAsync(i => i.Id == request.InvoiceId, cancellationToken);


            //Check If Invoice Exist
            if (response is null)
                return Result<InvoiceResponse>.Failed(404, "Null.Error", $"The invoice with Id {request.InvoiceId} is not found!");


            // return Success Message With The Data
            return Result<InvoiceResponse>.Success(response, 201);
        }
    }
}
