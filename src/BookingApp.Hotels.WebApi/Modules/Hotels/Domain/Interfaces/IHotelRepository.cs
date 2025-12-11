using BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Entities;

namespace BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Interfaces;

public interface IHotelRepository
{
    public Task<Hotel?> GetByIdAsync(int id);
    public Task SaveAsync(Hotel hotel);
}