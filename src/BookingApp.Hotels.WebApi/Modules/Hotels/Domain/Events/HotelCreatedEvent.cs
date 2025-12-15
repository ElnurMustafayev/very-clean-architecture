namespace BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Events;

using BookingApp.Hotels.WebApi.Shared.Domain.Events;

public sealed record HotelCreatedEvent(
    Guid HotelId,
    DateTime OccurredAt
) : IDomainEvent
{
    
}