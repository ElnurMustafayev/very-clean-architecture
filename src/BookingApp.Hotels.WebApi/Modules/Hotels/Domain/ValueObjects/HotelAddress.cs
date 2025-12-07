namespace BookingApp.Hotels.WebApi.Modules.Hotels.Domain.ValueObjects;

using MongoDB.Bson.Serialization.Attributes;

public class HotelAddress
{
    [BsonElement("country")]
    public required string Country { get; set; }

    [BsonElement("city")]
    public required string City { get; set; }

    [BsonElement("street")]
    public required string Street { get; set; }
}