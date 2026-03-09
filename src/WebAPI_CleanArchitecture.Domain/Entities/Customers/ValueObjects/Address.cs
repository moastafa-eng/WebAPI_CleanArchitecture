namespace WebAPI_CleanArchitecture.Domain.Entities.Customers.ValueObjects
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
