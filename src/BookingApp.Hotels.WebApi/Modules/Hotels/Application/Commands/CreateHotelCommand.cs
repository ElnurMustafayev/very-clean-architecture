namespace BookingApp.Hotels.WebApi.Modules.Hotels.Application.Commands;

using BookingApp.Hotels.WebApi.Modules.Hotels.Application.DTOs;
using MediatR;

public record CreateHotelCommand(
    string Name,
    string Description
) : IRequest<HotelDto>;