namespace BookingApp.Hotels.WebApi.Shared.Domain.Aggregates;

using BookingApp.Hotels.WebApi.Shared.Domain.Entities;
using BookingApp.Hotels.WebApi.Shared.Domain.Events;

public abstract class AggregateRoot<TId> : Entity<TId>
{
    private List<IDomainEvent> domainEvents = new List<IDomainEvent>();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        this.domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        this.domainEvents.Clear();
    }
}