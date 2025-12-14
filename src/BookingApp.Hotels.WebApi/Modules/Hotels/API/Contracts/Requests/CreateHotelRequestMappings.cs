namespace BookingApp.Hotels.WebApi.Modules.Hotels.API.Contracts.Requests;

using AutoMapper;
using BookingApp.Hotels.WebApi.Modules.Hotels.Application.Commands;

public class CreateHotelRequestMappings : Profile
{
    public CreateHotelRequestMappings()
    {
        base.CreateMap<CreateHotelRequest, CreateHotelCommand>();
    }
}