namespace BookingApp.Hotels.WebApi.Shared.Domain.Entities;

public abstract class Entity<TId>
{
    public TId? Id { get; protected set; }

    public override bool Equals(object? obj)
    {
        if(obj is not Entity<TId> other)
            return false;

        if(object.ReferenceEquals(this, other) == true)
            return true;

        if(this.Id is null || other.Id is null)
            return false;

        return Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType(), this.Id);
    }
}