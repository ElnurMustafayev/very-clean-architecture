namespace BookingApp.Hotels.WebApi.Modules.Hotels.Domain.ValueObjects;

using BookingApp.Hotels.WebApi.Shared.Domain.Exceptions;
using BookingApp.Hotels.WebApi.Shared.Domain.ValueObjects;

public class HotelAddress : ValueObject
{
    public string Country { get; private set; }

    public string City { get; private set; }

    public string Street { get; private set; }

    private HotelAddress(string country, string city, string street)
    {
        this.Country = country;
        this.City = city;
        this.Street = street;
    }

    public static HotelAddress Create(string country, string city, string street)
    {
        if (string.IsNullOrWhiteSpace(country))
            throw new DomainException("Country cannot be empty.");

        if (string.IsNullOrWhiteSpace(city))
            throw new DomainException("City cannot be empty.");

        if (string.IsNullOrWhiteSpace(street))
            throw new DomainException("Street cannot be empty.");
        
        return new HotelAddress(country, city, street);
    }
}