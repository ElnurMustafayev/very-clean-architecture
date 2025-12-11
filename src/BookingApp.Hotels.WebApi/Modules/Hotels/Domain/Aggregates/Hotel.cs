namespace BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Entities;

using BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Events;
using BookingApp.Hotels.WebApi.Modules.Hotels.Domain.ValueObjects;
using BookingApp.Hotels.WebApi.Shared.Domain.Aggregates;
using BookingApp.Hotels.WebApi.Shared.Domain.Exceptions;

public class Hotel : AggregateRoot<int>
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public HotelAddress? Address { get; private set; }
    public double? Rating { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Hotel() {}

    private Hotel(string name, string description, HotelAddress? address, double? rating)
    {
        this.Name = name;
        this.Description = description;
        this.Address = address;
        this.Rating = rating;

        this.CreatedAt = DateTime.UtcNow;
        this.UpdatedAt = DateTime.UtcNow;
    }

    public static Hotel Create(string name, string description, HotelAddress? address, double? rating)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("Hotel name must be not empty!");
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new DomainException("Hotel description must be not empty!");
        }

        if (rating is not null)
        {
            if(rating < 1 || rating > 5)
            {
                throw new DomainException("Hotel Rating must be between 0 and 5");
            }
        }

        var result = new Hotel(name, description, address, rating);

        return result;
    }
}