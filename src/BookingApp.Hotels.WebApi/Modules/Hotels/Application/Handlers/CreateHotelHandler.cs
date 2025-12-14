namespace BookingApp.Hotels.WebApi.Modules.Hotels.Application.Handlers;

using BookingApp.Hotels.WebApi.Modules.Hotels.Application.Commands;
using BookingApp.Hotels.WebApi.Modules.Hotels.Application.DTOs;
using BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Aggregates;
using BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Interfaces;
using MediatR;

public class CreateHotelHandler : IRequestHandler<CreateHotelCommand, HotelDto>
{
    private readonly IHotelRepository repository;

    public CreateHotelHandler(IHotelRepository repository)
    {
        this.repository = repository;
    }
    public async Task<HotelDto> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        var newHotel = Hotel.Create(request.Name, request.Description, null, null);

        await this.repository.SaveAsync(newHotel);

        return new HotelDto(newHotel.Id);
    }
}