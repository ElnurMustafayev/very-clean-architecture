namespace BookingApp.Hotels.WebApi.Modules.Hotels.Application.Handlers;

using BookingApp.Hotels.WebApi.Modules.Hotels.Application.Commands;
using BookingApp.Hotels.WebApi.Modules.Hotels.Application.DTOs;
using MediatR;

public class CreateHotelHandler : IRequestHandler<CreateHotelCommand, HotelDto>
{
    public async Task<HotelDto> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        return new HotelDto(100);
    }
}