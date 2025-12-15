using System.Data;

namespace BookingApp.Hotels.WebApi.Shared.Infrastructure.Persistence.UnitOfWork;

public interface IUnitOfWork
{
    public IDbConnection Connection { get; }
    public IDbTransaction Transaction { get; }

    Task CommitAsync();
    void Rollback();
}