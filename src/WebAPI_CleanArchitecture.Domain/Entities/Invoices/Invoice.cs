using System;
using WebAPI_CleanArchitecture.Domain.Abstraction;
using WebAPI_CleanArchitecture.Domain.Entities.Customers;
using WebAPI_CleanArchitecture.Domain.Entities.InvoiceItems;
using WebAPI_CleanArchitecture.Domain.Entities.InvoiceItems.ValueObjects;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices.DTOs;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices.Events;
using WebAPI_CleanArchitecture.Domain.Entities.Invoices.ValueObjects;
using WebAPI_CleanArchitecture.Domain.Entities.Products;
using WebAPI_CleanArchitecture.Domain.Entities.Shared;

namespace WebAPI_CleanArchitecture.Domain.Entities.Invoices
{
    public sealed class Invoice : BaseEntity
    {
        public Invoice(PoNumber poNumber, Money totalBalance,
            ICollection<InvoiceItem> purchasedProducts, Guid customerId, Guid InvoiceId) : base(InvoiceId)
        {
            PoNumber = poNumber;
            TotalBalance = totalBalance;
            PurchasedProducts = purchasedProducts;
            CustomerId = customerId;
        }


        // << Properties >>
        public PoNumber PoNumber { get; private set; } = null!;
        public Money TotalBalance { get; private set; } = null!;



        // << Navigational Properties >>
        public Customer Customer { get; private set; } = null!;
        public ICollection<InvoiceItem> PurchasedProducts { get; private set; } = null!;
        public Guid CustomerId { get; private set; } // FK



        // << Methods-Factory Design Pattern >>
        public static async Task<Invoice> Create(CreateInvoiceDto request, IUnitOfWork unitOfWork)
        {
            // check if PurchasedProducts is not null or empty
            if (request.PurchasedProducts is null || request.PurchasedProducts.Count == 0)
                throw new InvalidOperationException("Empty Invoice can not be created!");


            ICollection<InvoiceItem> purchaseProducts = [];
            var invoiceId = Guid.NewGuid();

            foreach(var purchaseProduct in request.PurchasedProducts)
            {
                // get product by id
                var product = await unitOfWork.GetRepository<Product>()
                    .GetByIdAsync(purchaseProduct.ProductId) ??
                    // throw ex if product can't be found
                    throw new ArgumentNullException($"Product with id: {purchaseProduct.ProductId} is not found!");

                // create invoice item
                var invoiceItem = new InvoiceItem
                (
                    new Money(product.UnitPrice.value),
                    new Quantity(purchaseProduct.Quantity),
                    invoiceId,
                    Guid.NewGuid());
                
                // add invoice item to purchased products
                purchaseProducts.Add(invoiceItem);
            }

            // calculate total balance of all invoice items
            var totalBalance = purchaseProducts.Sum(x => x.TotalPrice.value);

            var invoice = new Invoice
            (
                new PoNumber(request.PoNumber),
                new Money(totalBalance),
                purchaseProducts,
                request.CustomerId,
                invoiceId);

            // Raise Domain Event if every thing is alright
            invoice.RaiseDomainEvent(new InvoiceDomainCreateEvent(invoiceId));

            return invoice;
        }

        public void Update(UpdateInvoiceDto request)
        {
            PoNumber = new PoNumber (request.PoNumber);
        }
    }
}
