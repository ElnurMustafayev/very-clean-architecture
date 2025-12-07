namespace BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Entities;

using BookingApp.Hotels.WebApi.Modules.Hotels.Domain.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

public class Hotel
{
    [BsonId]
    public int Id { get; set; }

    [BsonElement("name")]
    public required string Name { get; set; }

    [BsonElement("rating")]
    public double? Rating { get; set; }

    [BsonElement("address")]
    public HotelAddress? Address { get; set; }

    [BsonElement("description")]
    public required string Description { get; set; }

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }

    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    public Hotel()
    {
        this.CreatedAt = DateTime.Now;
        this.UpdatedAt = DateTime.Now;
    }
}