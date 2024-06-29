namespace Bookify.Domain.Apartments;

public record Address(
    string Country,
    string ZipCode,
    string City,
    string Street);