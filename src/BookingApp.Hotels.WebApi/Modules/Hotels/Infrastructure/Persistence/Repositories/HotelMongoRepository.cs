namespace BookingApp.Hotels.WebApi.Modules.Hotels.Infrastructure.Persistence.Repositories;

using BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Aggregates;
using BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Interfaces;
using BookingApp.Hotels.WebApi.Modules.Hotels.Infrastructure.Persistence.UnitOfWork;
using MongoDB.Driver;

public class HotelMongoRepository : IHotelRepository
{
    private readonly IMongoCollection<Hotel> collection;
    private readonly IHotelUnitOfWork unitOfWork;

    public HotelMongoRepository(IHotelUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.collection = unitOfWork.Database.GetCollection<Hotel>("hotels");
    }

    public async Task<Hotel?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await this.collection
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task SaveAsync(Hotel aggregateRoot, CancellationToken cancellationToken)
    {
        var result = await this.collection
            .ReplaceOneAsync(
                filter: Builders<Hotel>.Filter.Eq(x => x.Id, aggregateRoot.Id),
                replacement: aggregateRoot,
                options: new ReplaceOptions
                {
                    IsUpsert = true
                },
                cancellationToken: cancellationToken
            );
    }
}