namespace BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Interfaces;

using BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Aggregates;
using BookingApp.Hotels.WebApi.Shared.Domain.Interfaces;

public interface IHotelRepository : IRepository<Hotel, Guid> {}