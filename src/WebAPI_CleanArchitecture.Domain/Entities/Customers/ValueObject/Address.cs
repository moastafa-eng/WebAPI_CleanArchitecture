using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_CleanArchitecture.Domain.Entities.Customers.ValueObject
{
    // record provides the Immutability => you can't change the values in the record after creation
    // record provide the value comparison
    // record is shorter than class
    public record Address(
        string City,
        string FirstLineAddress,
        string? SecondLineAddress,
        string Country,
        string PostCode);
   
}
