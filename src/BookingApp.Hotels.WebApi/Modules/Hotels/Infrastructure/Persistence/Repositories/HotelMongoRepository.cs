namespace BookingApp.Hotels.WebApi.Modules.Hotels.Infrastructure.Persistence.Repositories;

using BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Aggregates;
using BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Interfaces;
using BookingApp.Hotels.WebApi.Modules.Hotels.Infrastructure.Persistence.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class HotelMongoRepository : IHotelRepository
{
    private readonly HotelMongoDatabaseOptions databaseOptions;

    public HotelMongoRepository(IOptions<HotelMongoDatabaseOptions> databaseOptions)
    {
        this.databaseOptions = databaseOptions.Value;
    }

    public async Task<Hotel?> GetByIdAsync(Guid id)
    {
        var client = new MongoClient(this.databaseOptions.ConnectionString);
        var database = client.GetDatabase("hotels_db");

        var collection = database.GetCollection<Hotel>("hotels");

        return await collection
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync(CancellationToken.None);
    }

    public async Task SaveAsync(Hotel aggregateRoot)
    {
        var client = new MongoClient(this.databaseOptions.ConnectionString);
        var database = client.GetDatabase("hotels_db");

        var collection = database.GetCollection<Hotel>("hotels");

        var result = await collection.ReplaceOneAsync(
            filter: Builders<Hotel>.Filter.Eq(x => x.Id, aggregateRoot.Id),
            replacement: aggregateRoot,
            options: new ReplaceOptions
            {
                IsUpsert = true
            },
            cancellationToken: CancellationToken.None
        );
    }
}