namespace BookingApp.Hotels.WebApi.Shared.Domain.Interfaces;

using BookingApp.Hotels.WebApi.Shared.Domain.Aggregates;

public interface IRepository<TAggregateRoot, TId>
    where TAggregateRoot : AggregateRoot<TId>
    where TId : notnull
{
    public Task<TAggregateRoot?> GetByIdAsync(TId id, CancellationToken cancellationToken);
    public Task SaveAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken);
}