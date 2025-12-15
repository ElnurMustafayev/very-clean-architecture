namespace BookingApp.Hotels.WebApi.Modules.Hotels.Infrastructure.Persistence.UnitOfWork;

using BookingApp.Hotels.WebApi.Modules.Hotels.Infrastructure.Persistence.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class HotelUnitOfWork : IHotelUnitOfWork
{
    public IMongoClient Client { get; }
    public IMongoDatabase Database { get; }
    public IClientSessionHandle? Session { get; }

    public HotelUnitOfWork(IOptions<HotelMongoDatabaseOptions> databaseOptions)
    {
        this.Client = new MongoClient(databaseOptions.Value.ConnectionString);
        this.Database = this.Client.GetDatabase("hotels_db");
        
        //this.Session = this.Client.StartSession();
        //this.Session.StartTransaction();
    }

    public async Task AbortAsync(CancellationToken ct)
    {
        if(this.Session is not null)
            await this.Session.AbortTransactionAsync(ct);
    }

    public async Task CommitAsync(CancellationToken ct)
    {
        if(this.Session is not null)
            await this.Session.CommitTransactionAsync(ct);
    }

    public void Dispose()
    {
        this.Session?.Dispose();
    }
}