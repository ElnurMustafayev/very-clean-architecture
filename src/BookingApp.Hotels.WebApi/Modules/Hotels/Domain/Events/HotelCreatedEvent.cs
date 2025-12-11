namespace BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Events;

using BookingApp.Hotels.WebApi.Shared.Domain.Events;

public class HotelCreatedEvent : IDomainEvent
{
    public int HotelId { get; }
    public DateTime OccuredAt { get; } = DateTime.UtcNow;

    public HotelCreatedEvent(int hotelId)
    {
        this.HotelId = hotelId;
    }
}