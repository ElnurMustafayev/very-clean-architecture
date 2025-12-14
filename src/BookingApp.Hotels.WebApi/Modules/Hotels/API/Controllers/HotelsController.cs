namespace BookingApp.Hotels.WebApi.Modules.Hotels.API.Controllers;

using AutoMapper;
using BookingApp.Hotels.WebApi.Modules.Hotels.API.Contracts.Requests;
using BookingApp.Hotels.WebApi.Modules.Hotels.API.Contracts.Response;
using BookingApp.Hotels.WebApi.Modules.Hotels.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HotelsController : ControllerBase
{
    private readonly ISender sender;
    private readonly IMapper mapper;

    public HotelsController(ISender sender, IMapper mapper)
    {
        this.mapper = mapper;
        this.sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<CreateHotelResponse>> CreateHotel(CreateHotelRequest request)
    {
        var command = this.mapper.Map<CreateHotelCommand>(request);

        var result = await this.sender.Send(command);

        return new CreateHotelResponse(result.Id);
    }
}