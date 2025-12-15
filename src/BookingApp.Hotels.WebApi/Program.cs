using System.Reflection;
using BookingApp.Hotels.WebApi.Modules.Hotels.Domain.Interfaces;
using BookingApp.Hotels.WebApi.Modules.Hotels.Infrastructure.Persistence.Options;
using BookingApp.Hotels.WebApi.Modules.Hotels.Infrastructure.Persistence.Outbox;
using BookingApp.Hotels.WebApi.Modules.Hotels.Infrastructure.Persistence.Repositories;
using BookingApp.Hotels.WebApi.Modules.Hotels.Infrastructure.Persistence.UnitOfWork;
using BookingApp.Hotels.WebApi.Shared.API.Middlewares;
using BookingApp.Hotels.WebApi.Shared.Application.Behaviors;
using FluentValidation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOutboxWriter, MongoOutboxWriter>();
builder.Services.AddScoped<IHotelRepository, HotelMongoRepository>();
builder.Services.AddScoped<IHotelUnitOfWork, HotelUnitOfWork>();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(config => {}, Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
builder.Services.AddOptions<HotelMongoDatabaseOptions>()
    .Configure(options =>
    {
        var connectionString = Environment.GetEnvironmentVariable("HOTELS_CONNECTION_STRING");
        ArgumentNullException.ThrowIfNullOrWhiteSpace(connectionString);

        options.ConnectionString = connectionString;
    });

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapOpenApi();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();