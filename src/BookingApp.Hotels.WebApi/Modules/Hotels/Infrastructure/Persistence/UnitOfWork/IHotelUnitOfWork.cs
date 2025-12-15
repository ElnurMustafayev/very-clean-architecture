namespace BookingApp.Hotels.WebApi.Modules.Hotels.Infrastructure.Persistence.UnitOfWork;

using MongoDB.Driver;

public interface IHotelUnitOfWork : IDisposable
{
    IMongoDatabase Database { get; }
    IClientSessionHandle? Session { get; }

    Task CommitAsync(CancellationToken ct);
    Task AbortAsync(CancellationToken ct);
}