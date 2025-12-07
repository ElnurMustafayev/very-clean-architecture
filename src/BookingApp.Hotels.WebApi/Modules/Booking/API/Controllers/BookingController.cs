namespace BookingApp.Hotels.WebApi.Modules.Booking.API.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    [HttpPost("{hotelId}")]
    public async Task<ActionResult> BookHotelRoom(long hotelId)
    {
        string roomId = "FROM_SOMEWHERE";

        var UrlOfGetEndpoint = base.Url.Action(
            action: nameof(GetHotelRoom),
            values: new
            {
                hotelId = hotelId,
                roomId = roomId,
            });
        
        return base.Accepted(uri: UrlOfGetEndpoint);
    }

    [HttpGet("{hotelId}/{roomId}")]
    public async Task<ActionResult> GetHotelRoom(long hotelId, string roomId)
    {
        return base.Ok();
    }
}