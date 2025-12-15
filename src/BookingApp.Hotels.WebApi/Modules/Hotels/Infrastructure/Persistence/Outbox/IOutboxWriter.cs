using BookingApp.Hotels.WebApi.Shared.Domain.Events;

namespace BookingApp.Hotels.WebApi.Modules.Hotels.Infrastructure.Persistence.Outbox;

public interface IOutboxWriter
{
    public Task SaveAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken);
}