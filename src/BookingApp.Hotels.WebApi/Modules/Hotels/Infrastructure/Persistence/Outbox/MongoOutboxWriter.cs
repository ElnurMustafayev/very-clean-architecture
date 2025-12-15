namespace BookingApp.Hotels.WebApi.Modules.Hotels.Infrastructure.Persistence.Outbox;

using System.Text.Json;
using BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Events;
using BookingApp.Hotels.WebApi.Modules.Hotels.Infrastructure.Persistence.UnitOfWork;
using BookingApp.Hotels.WebApi.Shared.Domain.Events;
using MongoDB.Bson;
using MongoDB.Driver;

public class MongoOutboxWriter : IOutboxWriter
{
    private readonly IHotelUnitOfWork unitOfWork;
    private IMongoCollection<BsonDocument> collection;

    public MongoOutboxWriter(IHotelUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        this.collection = unitOfWork.Database.GetCollection<BsonDocument>("hotel_outbox");
    }

    public async Task SaveAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken)
    {
        if (domainEvents == null)
            return;

        await this.collection.InsertManyAsync(
            domainEvents.Select(e =>
            {
                var doc = e.ToBsonDocument(e.GetType());

                doc["_type"] = e.GetType().Name;

                return doc;
            }),
            cancellationToken: cancellationToken);
    }
}