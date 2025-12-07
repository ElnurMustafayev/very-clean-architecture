namespace BookingApp.Hotels.WebApi.Modules.Hotels.API.Controllers;

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

    public HotelsController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<CreateHotelResponse>> CreateHotel(CreateHotelRequest request)
    {
        var command = new CreateHotelCommand(request.Name, request.Description);

        var result = await this.sender.Send(command);

        return new CreateHotelResponse(result.Id);
    }
}