namespace BookingApp.Hotels.WebApi.Modules.Hotels.Application.Handlers;

using BookingApp.Hotels.WebApi.Modules.Hotels.Application.Commands;
using BookingApp.Hotels.WebApi.Modules.Hotels.Application.DTOs;
using BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Aggregates;
using BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Interfaces;
using BookingApp.Hotels.WebApi.Modules.Hotels.Infrastructure.Persistence.Outbox;
using BookingApp.Hotels.WebApi.Modules.Hotels.Infrastructure.Persistence.UnitOfWork;
using MediatR;

public class CreateHotelHandler : IRequestHandler<CreateHotelCommand, HotelDto>
{
    private readonly IHotelUnitOfWork unitOfWork;
    private readonly IHotelRepository repository;
    private readonly IOutboxWriter outboxWriter;

    public CreateHotelHandler(
        IHotelUnitOfWork unitOfWork,
        IHotelRepository repository,
        IOutboxWriter outboxWriter
        )
    {
        this.unitOfWork = unitOfWork;
        this.repository = repository;
        this.outboxWriter = outboxWriter;
    }
    public async Task<HotelDto> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newHotel = Hotel.Create(request.Name, request.Description, null, null);

            await this.repository.SaveAsync(newHotel, cancellationToken);
            await this.outboxWriter.SaveAsync(newHotel.DomainEvents, cancellationToken);

            await this.unitOfWork.CommitAsync(cancellationToken);

            newHotel.ClearDomainEvents();

            return new HotelDto(newHotel.Id);
        }
        catch(Exception)
        {
            await this.unitOfWork.AbortAsync(cancellationToken);
            throw;
        }
    }
}